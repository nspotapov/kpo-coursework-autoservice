using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormMainAdmin : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly OrderRepository _orderRepository;
        private readonly ClientRepository _clientRepository;
        private readonly CarRepository _carRepository;
        private readonly UserRepository _userRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly PartRepository _partRepository;
        private readonly MasterRepository _masterRepository;
        private readonly CheckRepository _checkRepository;

        public FormMainAdmin()
        {
            InitializeComponent();
            InitializeCurrentUser();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _orderRepository = new OrderRepository(_dbContext);
            _clientRepository = new ClientRepository(_dbContext);
            _carRepository = new CarRepository(_dbContext);
            _userRepository = new UserRepository(_dbContext);
            _serviceRepository = new ServiceRepository(_dbContext);
            _partRepository = new PartRepository(_dbContext);
            _masterRepository = new MasterRepository(_dbContext);
            _checkRepository = new CheckRepository(_dbContext);
        }

        /// <summary>
        /// Инициализация информации о текущем пользователе
        /// </summary>
        private void InitializeCurrentUser()
        {
            if (CurrentUser.User != null)
            {
                var roleName = CurrentUser.User.Role == UserRole.Admin ? "Администратор" : "Менеджер";
                SetTitle($"{CurrentUser.User.FullName} ({roleName})");
                ApplyRoleBasedAccess();
            }
        }

        /// <summary>
        /// Применение доступа на основе роли пользователя
        /// </summary>
        private void ApplyRoleBasedAccess()
        {
            if (CurrentUser.IsAdmin)
            {
                // Администратор: все пункты меню видны
                SystemUsersToolStripMenuItem.Visible = true;
                ReferenceServicesToolStripMenuItem.Visible = true;
                ReferencePartsToolStripMenuItem.Visible = true;
                MastersToolStripMenuItem.Visible = true;
                ChecksToolStripMenuItem.Visible = true;
                
                // Вкладки: только просмотр (CRUD отключены)
                SetCrudButtonsEnabled(tabPageOrders, false);
                SetCrudButtonsEnabled(tabPageClients, false);
                SetCrudButtonsEnabled(tabPageCars, false);
            }
            else if (CurrentUser.IsManager)
            {
                // Менеджер: не видит меню админа
                SystemUsersToolStripMenuItem.Visible = false;
                ReferenceServicesToolStripMenuItem.Visible = false;
                ReferencePartsToolStripMenuItem.Visible = false;
                MastersToolStripMenuItem.Visible = false;
                
                // Вкладки менеджера: CRUD активны
                SetCrudButtonsEnabled(tabPageOrders, true);
                SetCrudButtonsEnabled(tabPageClients, true);
                SetCrudButtonsEnabled(tabPageCars, true);
            }
        }

        /// <summary>
        /// Установить доступность кнопок CRUD для вкладки
        /// </summary>
        private void SetCrudButtonsEnabled(TabPage tabPage, bool enabled)
        {
            // Находим панель с кнопками на вкладке и блокируем/разблокируем
            foreach (Control control in tabPage.Controls)
            {
                if (control is FlowLayoutPanel panel)
                {
                    foreach (Control btn in panel.Controls)
                    {
                        if (btn is Button button)
                        {
                            button.Enabled = enabled;
                        }
                    }
                }
            }
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string version = ThisAssembly.Git.Tag;

            if (string.IsNullOrEmpty(version))
            {
                version = ThisAssembly.Git.Commit;
            }

            MessageBox.Show(
                $"Информационная система: Автосервис\n" +
                $"Версия: {version}\n" +
                $"Дата релиза: {ThisAssembly.Git.CommitDate}\n" +
                $"Автор: Потапов Н.С.",
                "Информация о программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ClearStatusLabel()
        {
            SetStatusLabel(string.Empty, DefaultForeColor);
        }

        private void SetStatusLabel(string text, Color color)
        {
            toolStripStatusLabel.Text = text;
            toolStripStatusLabel.ForeColor = color;
        }

        private void ShowErrorStatus(string text)
        {
            SetStatusLabel("Ошибка! " + text, Color.Red);
        }

        private void ShowInfoStatus(string text)
        {
            SetStatusLabel(text, DefaultForeColor);
        }

        private void SetTitle(string text)
        {
            Text = Settings.GlobalConstants.AppName + (string.IsNullOrEmpty(text) ? string.Empty : (" " + text));
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            ClearStatusLabel();
            PrepareOrdersFilters();
            PrepareClientsFilters();
            
            // Загрузка данных
            await LoadOrdersAsync();
            await LoadCarsAsync();
            await LoadClientsAsync();
        }

        private static DateTime GetWeekStartDate(DateTime date, System.Globalization.CultureInfo cultureInfo)
        {
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            return date.AddDays((Int32)firstDayOfWeek - (Int32)date.DayOfWeek);
        }

        private static DateTime GetWeekStartDate(DateTime date)
        {
            return GetWeekStartDate(date, Thread.CurrentThread.CurrentCulture);
        }

        private static DateTime GetCurrentWeekStartDate()
        {
            return GetWeekStartDate(DateTime.Now.Date);
        }

        private void PrepareOrdersFilters()
        {
            var currentWeekStartDate = GetCurrentWeekStartDate();

            dateTimePickerOrderFilterDateFrom.Value = currentWeekStartDate;
            dateTimePickerOrderFilterDateTo.Value = currentWeekStartDate.AddDays(13);

            comboBoxOrderFilterStatus.SelectedIndex = 0;
            comboBoxOrderFilterWorker.SelectedIndex = 0;
        }

        private void PrepareClientsFilters()
        {
            comboBoxClientsTypeFilter.SelectedIndex = 0;
        }

        private async Task ShowCreateOrEditDialog(bool isEditDialog)
        {
            if (tabControl.SelectedTab == tabPageOrders)
            {
                var form = new FormOrder();

                if (isEditDialog)
                {
                    if (dataGridViewOrders.SelectedRows.Count == 1)
                    {
                        form.OrderId = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells["ColumnOrderId"].Value);
                    }
                    else
                    {
                        return;
                    }
                }

                var dialogResult = form.ShowDialog();
                
                // Отладка: выводим результат диалога
                System.Diagnostics.Debug.WriteLine($"FormOrder закрыта с DialogResult={dialogResult}, OrderId={form.OrderId}");
                
                if (dialogResult == DialogResult.OK)
                {
                    System.Diagnostics.Debug.WriteLine("Обновляем список заявок...");
                    await LoadOrdersAsync();
                    System.Diagnostics.Debug.WriteLine("Список заявок обновлён");
                }
            }
            else if (tabControl.SelectedTab == tabPageCars)
            {
                var form = new FormCar();

                if (isEditDialog)
                {
                    if (dataGridViewCars.SelectedRows.Count == 1)
                    {
                        form.CarId = Convert.ToInt32(dataGridViewCars.SelectedRows[0].Cells["ColumnCarId"].Value);
                    }
                    else
                    {
                        return;
                    }
                }

                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    await LoadCarsAsync();
                }
            }
            else if (tabControl.SelectedTab == tabPageClients)
            {
                var form = new FormClient();

                if (isEditDialog)
                {
                    if (dataGridViewClients.SelectedRows.Count == 1)
                    {
                        form.ClientId = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells["ColumnClientId"].Value);
                    }
                    else
                    {
                        return;
                    }
                }

                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    await LoadClientsAsync();
                }
            }
        }

        private async void CreateItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ShowCreateOrEditDialog(isEditDialog: false);
        }

        private async void EditItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ShowCreateOrEditDialog(isEditDialog: true);
        }

        /// <summary>
        /// Открытие записи по двойному клику
        /// </summary>
        private async void dataGridViewOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowCreateOrEditDialog(isEditDialog: true);
            }
        }

        private async void dataGridViewCars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowCreateOrEditDialog(isEditDialog: true);
            }
        }

        private async void dataGridViewClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowCreateOrEditDialog(isEditDialog: true);
            }
        }

        /// <summary>
        /// Удаление записи по Delete
        /// </summary>
        private async void dataGridViewOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewOrders.SelectedRows.Count > 0)
            {
                e.SuppressKeyPress = true;
                await DeleteSelectedOrderAsync();
            }
        }

        private async void dataGridViewCars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewCars.SelectedRows.Count > 0)
            {
                e.SuppressKeyPress = true;
                await DeleteSelectedCarAsync();
            }
        }

        private async void dataGridViewClients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewClients.SelectedRows.Count > 0)
            {
                e.SuppressKeyPress = true;
                await DeleteSelectedClientAsync();
            }
        }

        private async Task DeleteSelectedOrderAsync()
        {
            if (dataGridViewOrders.SelectedRows.Count == 1)
            {
                var orderId = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells["ColumnOrderId"].Value);
                var orderNumber = dataGridViewOrders.SelectedRows[0].Cells["ColumnOrderNumber"].Value.ToString();

                // Проверяем, есть ли чек для этой заявки
                var existingCheck = await _dbContext.Checks
                    .FirstOrDefaultAsync(c => c.OrderId == orderId);

                if (existingCheck != null)
                {
                    MessageBox.Show(
                        $"Нельзя удалить заявку \"{orderNumber}\", так как для неё уже создан чек.\n\n" +
                        $"Сначала удалите чек.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Удалить заявку \"{orderNumber}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Создаём НОВЫЙ контекст для удаления, чтобы избежать конфликтов отслеживания
                    var deleteContext = new AutoserviceDbContext(
                        new DbContextOptionsBuilder<AutoserviceDbContext>()
                            .UseNpgsql(Settings.DBConfig.ConnectionString)
                            .Options);

                    var order = await deleteContext.Orders.FindAsync(orderId);
                    if (order != null)
                    {
                        deleteContext.Orders.Remove(order);
                        await deleteContext.SaveChangesAsync();
                        await LoadOrdersAsync();
                    }
                }
            }
        }

        private async Task DeleteSelectedCarAsync()
        {
            if (dataGridViewCars.SelectedRows.Count == 1)
            {
                var carId = Convert.ToInt32(dataGridViewCars.SelectedRows[0].Cells["ColumnCarId"].Value);
                var carInfo = dataGridViewCars.SelectedRows[0].Cells["ColumnCarStateMark"].Value.ToString();

                var result = MessageBox.Show($"Удалить автомобиль \"{carInfo}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var deleteContext = new AutoserviceDbContext(
                        new DbContextOptionsBuilder<AutoserviceDbContext>()
                            .UseNpgsql(Settings.DBConfig.ConnectionString)
                            .Options);

                    var car = await deleteContext.Cars.FindAsync(carId);
                    if (car != null)
                    {
                        deleteContext.Cars.Remove(car);
                        await deleteContext.SaveChangesAsync();
                        await LoadCarsAsync();
                    }
                }
            }
        }

        private async Task DeleteSelectedClientAsync()
        {
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                var clientId = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells["ColumnClientId"].Value);
                var clientName = dataGridViewClients.SelectedRows[0].Cells["ColumnClientContactInfo"].Value.ToString();

                var result = MessageBox.Show($"Удалить клиента \"{clientName}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var deleteContext = new AutoserviceDbContext(
                        new DbContextOptionsBuilder<AutoserviceDbContext>()
                            .UseNpgsql(Settings.DBConfig.ConnectionString)
                            .Options);

                    var client = await deleteContext.Clients.FindAsync(clientId);
                    if (client != null)
                    {
                        deleteContext.Clients.Remove(client);
                        await deleteContext.SaveChangesAsync();
                        await LoadClientsAsync();
                    }
                }
            }
        }

        private void dateTimePickerOrderFilterDateFrom_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void dateTimePickerOrderFilterDateTo_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void comboBoxOrderFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void comboBoxOrderFilterWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void comboBoxClientsTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат поиска
        }

        private void SystemUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открыть окно управления списком системных пользователей
            var form = new FormUsersList();
            form.ShowDialog();
        }

        private void ReferenceServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открыть окно управления услугами
            var form = new FormServicesList();
            form.ShowDialog();
        }

        private void ReferencePartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открыть окно управления запчастями
            var form = new FormPartsList();
            form.ShowDialog();
        }

        private void MastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открыть окно управления мастерами
            var form = new FormMastersList();
            form.ShowDialog();
        }

        private void ChecksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открыть окно управления чеками
            var form = new FormChecksList();
            form.ShowDialog();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Выход из системы
            var result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Выход из системы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Очищаем данные текущего пользователя
                CurrentUser.Logout();

                // Закрываем главную форму - цикл авторизации продолжится в Program.cs
                Close();
            }
        }

        private void FocusOnSearchFieldOnCurrentTab()
        {
            if (tabControl.SelectedTab == tabPageOrders)
            {
                textBoxOrderFilterSearch.Focus();
            }
            else if (tabControl.SelectedTab == tabPageCars)
            {
                textBoxCarsFilterSearch.Focus();
            }
            else if (tabControl.SelectedTab == tabPageClients)
            {
                textBoxClientsFilterSearch.Focus();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                FocusOnSearchFieldOnCurrentTab();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D1))
            {
                tabControl.SelectTab(tabPageOrders);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D2))
            {
                tabControl.SelectTab(tabPageCars);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D3))
            {
                tabControl.SelectTab(tabPageClients);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Data Loading

        private async Task LoadOrdersAsync()
        {
            try
            {
                // Используем AsNoTracking() для получения свежих данных из БД
                var orders = await _dbContext.Orders
                    .AsNoTracking()
                    .Include(o => o.Master)
                    .Include(o => o.Car)
                    .Include(o => o.Client)
                    .OrderByDescending(o => o.CreatedAt)
                    .ToListAsync();

                dataGridViewOrders.Rows.Clear();
                foreach (var order in orders)
                {
                    var statusName = order.Status switch
                    {
                        OrderStatus.Pending => "Ожидает",
                        OrderStatus.InProgress => "В работе",
                        OrderStatus.Completed => "Выполнена",
                        OrderStatus.Overdue => "Просрочена",
                        OrderStatus.Cancelled => "Отменена",
                        _ => order.Status.ToString()
                    };

                    dataGridViewOrders.Rows.Add(
                        order.Id,
                        order.OrderNumber,
                        order.ServiceDateTime.ToString("dd.MM.yyyy"),
                        order.ServiceDateTime.ToString("HH:mm"),
                        statusName,
                        order.Master?.FullName ?? "-",
                        $"{order.Car.Brand} {order.Car.Model}",
                        order.Client.FullName
                    );
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки заявок: {ex.Message}");
            }
        }

        private async Task LoadCarsAsync()
        {
            try
            {
                var cars = await _carRepository.GetAllAsync();

                dataGridViewCars.Rows.Clear();
                foreach (var car in cars)
                {
                    dataGridViewCars.Rows.Add(
                        car.Id,
                        car.StateMark ?? "-",
                        car.Brand,
                        car.Model,
                        car.ProductionYear?.ToString() ?? "-",
                        car.Color ?? "-",
                        car.VinNumber ?? "-"
                    );
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки автомобилей: {ex.Message}");
            }
        }

        private async Task LoadClientsAsync()
        {
            try
            {
                var clients = await _clientRepository.GetAllAsync();
                
                dataGridViewClients.Rows.Clear();
                foreach (var client in clients)
                {
                    var typeName = client.Type == ClientType.Individual ? "Физ. лицо" : "Юр. лицо";
                    var contactInfo = $"{client.FullName} ({client.Phone})";
                    
                    dataGridViewClients.Rows.Add(
                        client.Id,
                        typeName,
                        contactInfo
                    );
                }
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки клиентов: {ex.Message}");
            }
        }

        #endregion

        #region Search Handlers

        private async void buttonOrdersFiltersSearchSubmit_Click(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private async void buttonCarsFiltersSearchSubmit_Click(object sender, EventArgs e)
        {
            await LoadCarsAsync();
        }

        private async void buttonClientsFiltersSearchSubmit_Click(object sender, EventArgs e)
        {
            await LoadClientsAsync();
        }

        #endregion

        #region Additional Load Methods

        private async Task LoadUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();

                // Находим вкладку пользователей (если есть) или обновляем через меню
                // В данной реализации главная форма не отображает пользователей в DataGridView
                // Поэтому метод оставлен для будущего расширения
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки пользователей: {ex.Message}");
            }
        }

        private async Task LoadServicesAsync()
        {
            try
            {
                var services = await _serviceRepository.GetAllAsync();

                // Главная форма не отображает услуги в DataGridView
                // Метод оставлен для будущего расширения
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки услуг: {ex.Message}");
            }
        }

        private async Task LoadPartsAsync()
        {
            try
            {
                var parts = await _partRepository.GetAllAsync();

                // Главная форма не отображает запчасти в DataGridView
                // Метод оставлен для будущего расширения
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки запчастей: {ex.Message}");
            }
        }

        private async Task LoadMastersAsync()
        {
            try
            {
                var masters = await _masterRepository.GetAllAsync();

                // Главная форма не отображает мастеров в DataGridView
                // Метод оставлен для будущего расширения
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки мастеров: {ex.Message}");
            }
        }

        private async Task LoadChecksAsync()
        {
            try
            {
                var checks = await _checkRepository.GetAllAsync();

                // Главная форма не отображает чеки в DataGridView
                // Метод оставлен для будущего расширения
            }
            catch (Exception ex)
            {
                ShowErrorStatus($"Ошибка загрузки чеков: {ex.Message}");
            }
        }

        #endregion
    }
}
