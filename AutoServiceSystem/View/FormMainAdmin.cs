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
        
        // Таймеры для debounce поиска
        private readonly System.Windows.Forms.Timer _ordersSearchTimer;
        private readonly System.Windows.Forms.Timer _carsSearchTimer;
        private readonly System.Windows.Forms.Timer _clientsSearchTimer;

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
            
            // Инициализация таймеров для debounce поиска (300 мс)
            _ordersSearchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _ordersSearchTimer.Tick += OrdersSearchTimer_Tick;
            
            _carsSearchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _carsSearchTimer.Tick += CarsSearchTimer_Tick;
            
            _clientsSearchTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _clientsSearchTimer.Tick += ClientsSearchTimer_Tick;
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
                ReportsToolStripMenuItem.Visible = true;

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
                ReportsToolStripMenuItem.Visible = false;

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

            try
            {
                // Сначала загружаем справочники для фильтров
                await LoadMastersToComboBoxAsync();
                PrepareClientsFilters();

                // Заполняем статусы заявок
                comboBoxOrderFilterStatus.Items.Clear();
                comboBoxOrderFilterStatus.Items.Add("Все статусы");
                comboBoxOrderFilterStatus.Items.Add("Ожидает");
                comboBoxOrderFilterStatus.Items.Add("В работе");
                comboBoxOrderFilterStatus.Items.Add("Выполнена");
                comboBoxOrderFilterStatus.Items.Add("Просрочена");
                comboBoxOrderFilterStatus.Items.Add("Отменена");

                // Временно отключаем обработчики событий, чтобы не срабатывала фильтрация при инициализации
                dateTimePickerOrderFilterDateFrom.ValueChanged -= dateTimePickerOrderFilter_ValueChanged;
                dateTimePickerOrderFilterDateTo.ValueChanged -= dateTimePickerOrderFilter_ValueChanged;
                comboBoxOrderFilterStatus.SelectedIndexChanged -= comboBoxOrderFilter_SelectedIndexChanged;
                comboBoxOrderFilterWorker.SelectedIndexChanged -= comboBoxOrderFilter_SelectedIndexChanged;
                textBoxOrderFilterSearch.TextChanged -= TextBoxSearch_TextChanged;

                // Устанавливаем даты по умолчанию (сегодня - конец текущего месяца) с DateTimeKind.Utc
                var today = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc);
                var endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month), 0, 0, 0, DateTimeKind.Utc);
                dateTimePickerOrderFilterDateFrom.Value = today;
                dateTimePickerOrderFilterDateTo.Value = endOfMonth;
                comboBoxOrderFilterStatus.SelectedIndex = 0;
                comboBoxOrderFilterWorker.SelectedIndex = 0;

                // Включаем обработчики событий обратно
                dateTimePickerOrderFilterDateFrom.ValueChanged += dateTimePickerOrderFilter_ValueChanged;
                dateTimePickerOrderFilterDateTo.ValueChanged += dateTimePickerOrderFilter_ValueChanged;
                comboBoxOrderFilterStatus.SelectedIndexChanged += comboBoxOrderFilter_SelectedIndexChanged;
                comboBoxOrderFilterWorker.SelectedIndexChanged += comboBoxOrderFilter_SelectedIndexChanged;
                textBoxOrderFilterSearch.TextChanged += TextBoxSearch_TextChanged;

                // Загрузка данных - используем LoadFilteredOrdersAsync для применения фильтров
                await LoadFilteredOrdersAsync();
                await LoadCarsAsync();
                await LoadClientsAsync();

                ShowInfoStatus("Приложение готово к работе");
            }
            catch (Exception ex)
            {
                var errorMsg = $"Ошибка загрузки: {ex.Message}\nВнутреннее исключение: {ex.InnerException?.Message}\nСтек: {ex.StackTrace}";
                System.Diagnostics.Debug.WriteLine(errorMsg);
                ShowErrorStatus(errorMsg);
            }
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

        private async Task LoadMastersToComboBoxAsync()
        {
            comboBoxOrderFilterWorker.Items.Clear();
            comboBoxOrderFilterWorker.Items.Add("Все мастера");

            // Создаём отдельный контекст для загрузки мастеров
            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;
            
            using var dbContext = new AutoserviceDbContext(optionsBuilder);
            var masters = await dbContext.Masters.ToListAsync();
            
            foreach (var master in masters)
            {
                comboBoxOrderFilterWorker.Items.Add(master.FullName);
            }
        }

        private void PrepareClientsFilters()
        {
            // Заполняем тип клиентов
            comboBoxClientsTypeFilter.Items.Clear();
            comboBoxClientsTypeFilter.Items.Add("Все типы");
            comboBoxClientsTypeFilter.Items.Add("Физ. лицо");
            comboBoxClientsTypeFilter.Items.Add("Юр. лицо");
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
            // Открыть окна управления чеками
            var form = new FormChecksList();
            form.ShowDialog();
        }

        private void ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открыть форму отчётов (доступно только администраторам)
            if (CurrentUser.IsAdmin)
            {
                var form = new FormReports();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Отчёты доступны только администраторам", "Доступ запрещён",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        /// <summary>
        /// Обработчик нажатия Enter в полях поиска
        /// </summary>
        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (sender == textBoxOrderFilterSearch)
                {
                    buttonOrdersFiltersSearchSubmit.PerformClick();
                }
                else if (sender == textBoxCarsFilterSearch)
                {
                    buttonCarsFiltersSearchSubmit.PerformClick();
                }
                else if (sender == textBoxClientsFilterSearch)
                {
                    buttonClientsFiltersSearchSubmit.PerformClick();
                }
            }
        }

        /// <summary>
        /// Обработчик изменения текста в полях поиска (мгновенный поиск с debounce)
        /// </summary>
        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Перезапускаем таймер для debounce
            if (sender == textBoxOrderFilterSearch)
            {
                _ordersSearchTimer.Stop();
                _ordersSearchTimer.Start();
            }
            else if (sender == textBoxCarsFilterSearch)
            {
                _carsSearchTimer.Stop();
                _carsSearchTimer.Start();
            }
            else if (sender == textBoxClientsFilterSearch)
            {
                _clientsSearchTimer.Stop();
                _clientsSearchTimer.Start();
            }
        }

        /// <summary>
        /// Обработчик таймера поиска заявок
        /// </summary>
        private async void OrdersSearchTimer_Tick(object sender, EventArgs e)
        {
            _ordersSearchTimer.Stop();
            await LoadFilteredOrdersAsync();
        }

        /// <summary>
        /// Обработчик таймера поиска автомобилей
        /// </summary>
        private async void CarsSearchTimer_Tick(object sender, EventArgs e)
        {
            _carsSearchTimer.Stop();
            await LoadFilteredCarsAsync();
        }

        /// <summary>
        /// Обработчик таймера поиска клиентов
        /// </summary>
        private async void ClientsSearchTimer_Tick(object sender, EventArgs e)
        {
            _clientsSearchTimer.Stop();
            await LoadFilteredClientsAsync();
        }

        /// <summary>
        /// Обработчик изменения фильтров заявок (даты, статус, мастер)
        /// </summary>
        private async void dateTimePickerOrderFilter_ValueChanged(object sender, EventArgs e)
        {
            await LoadFilteredOrdersAsync();
        }

        /// <summary>
        /// Обработчик изменения фильтров заявок (статус, мастер)
        /// </summary>
        private async void comboBoxOrderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadFilteredOrdersAsync();
        }

        /// <summary>
        /// Обработчик изменения типа клиента
        /// </summary>
        private async void comboBoxClientsTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadFilteredClientsAsync();
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
                // Создаём новый контекст для избежания конфликта запросов
                var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                    .UseNpgsql(Settings.DBConfig.ConnectionString)
                    .Options;
                
                using var dbContext = new AutoserviceDbContext(optionsBuilder);
                
                // Используем AsNoTracking() для получения свежих данных из БД
                var orders = await dbContext.Orders
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

        private async Task LoadFilteredOrdersAsync()
        {
            try
            {
                // Получаем параметры фильтрации
                var searchTerm = textBoxOrderFilterSearch.Text.Trim();
                
                // Конвертируем даты в UTC для PostgreSQL
                var dateFrom = dateTimePickerOrderFilterDateFrom.Value.Date.Kind == DateTimeKind.Utc 
                    ? dateTimePickerOrderFilterDateFrom.Value.Date 
                    : DateTime.SpecifyKind(dateTimePickerOrderFilterDateFrom.Value.Date, DateTimeKind.Utc);
                
                var dateTo = dateTimePickerOrderFilterDateTo.Value.Date.Kind == DateTimeKind.Utc 
                    ? dateTimePickerOrderFilterDateTo.Value.Date 
                    : DateTime.SpecifyKind(dateTimePickerOrderFilterDateTo.Value.Date, DateTimeKind.Utc);

                // Получаем статус из ComboBox
                OrderStatus? status = null;
                if (comboBoxOrderFilterStatus.SelectedIndex > 0)
                {
                    status = comboBoxOrderFilterStatus.SelectedIndex switch
                    {
                        1 => OrderStatus.Pending,
                        2 => OrderStatus.InProgress,
                        3 => OrderStatus.Completed,
                        4 => OrderStatus.Overdue,
                        5 => OrderStatus.Cancelled,
                        _ => null
                    };
                }

                // Получаем мастера из ComboBox
                int? masterId = null;
                if (comboBoxOrderFilterWorker.SelectedIndex > 0)
                {
                    // Создаём отдельный контекст для загрузки мастеров
                    var mastersOptions = new DbContextOptionsBuilder<AutoserviceDbContext>()
                        .UseNpgsql(Settings.DBConfig.ConnectionString)
                        .Options;

                    using var mastersContext = new AutoserviceDbContext(mastersOptions);
                    var masters = await mastersContext.Masters.ToListAsync();

                    var selectedMasterName = comboBoxOrderFilterWorker.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedMasterName))
                    {
                        var selectedMaster = masters.FirstOrDefault(m => m.FullName == selectedMasterName);
                        masterId = selectedMaster?.Id;
                    }
                }
                
                // Отладка: выводим параметры фильтрации
                System.Diagnostics.Debug.WriteLine($"[Filter] SearchTerm='{searchTerm}', DateFrom={dateFrom:yyyy-MM-dd}, DateTo={dateTo:yyyy-MM-dd}, Status={status?.ToString() ?? "null"}, MasterId={masterId?.ToString() ?? "null"}");

                // Создаём новый контекст для фильтрации заявок
                var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                    .UseNpgsql(Settings.DBConfig.ConnectionString)
                    .Options;

                using var dbContext = new AutoserviceDbContext(optionsBuilder);

                var query = dbContext.Orders
                    .AsNoTracking()
                    .Include(o => o.Client)
                    .Include(o => o.Car)
                    .Include(o => o.Master)
                    .AsQueryable();

                // Поиск по текстовому полю (без учёта регистра)
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var lowerSearchTerm = searchTerm.ToLower();
                    query = query.Where(o =>
                        o.OrderNumber.ToLower().Contains(lowerSearchTerm) ||
                        o.Client.LastName.ToLower().Contains(lowerSearchTerm) ||
                        o.Client.FirstName.ToLower().Contains(lowerSearchTerm) ||
                        o.Car.Brand.ToLower().Contains(lowerSearchTerm) ||
                        o.Car.Model.ToLower().Contains(lowerSearchTerm) ||
                        (o.Master != null && o.Master.LastName.ToLower().Contains(lowerSearchTerm)) ||
                        (o.Master != null && o.Master.FirstName.ToLower().Contains(lowerSearchTerm)));
                }

                // Фильтр по дате от
                if (dateFrom.Year < 2100)
                {
                    query = query.Where(o => o.ServiceDateTime >= dateFrom);
                }

                // Фильтр по дате до
                if (dateTo.Year < 2100)
                {
                    var dateToEnd = dateTo.Date.AddDays(1);
                    query = query.Where(o => o.ServiceDateTime < dateToEnd);
                }

                // Фильтр по статусу
                if (status.HasValue)
                {
                    query = query.Where(o => o.Status == status.Value);
                }

                // Фильтр по мастеру
                if (masterId.HasValue)
                {
                    query = query.Where(o => o.MasterId == masterId.Value);
                }

                System.Diagnostics.Debug.WriteLine($"[Filter] SQL запрос формируется...");
                
                var orders = await query.OrderByDescending(o => o.ServiceDateTime).ToListAsync();
                
                System.Diagnostics.Debug.WriteLine($"[Filter] Найдено заявок: {orders.Count}");

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
                var errorMsg = $"Ошибка фильтрации заявок: {ex.Message}\nВнутреннее исключение: {ex.InnerException?.Message}\nСтек: {ex.StackTrace}";
                System.Diagnostics.Debug.WriteLine(errorMsg);
                ShowErrorStatus(errorMsg);
            }
        }

        private async Task LoadFilteredCarsAsync()
        {
            try
            {
                var searchTerm = textBoxCarsFilterSearch.Text.Trim();
                
                // Создаём отдельный контекст для фильтрации автомобилей
                var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                    .UseNpgsql(Settings.DBConfig.ConnectionString)
                    .Options;

                using var dbContext = new AutoserviceDbContext(optionsBuilder);

                var query = dbContext.Cars
                    .Include(c => c.Owner)
                    .AsQueryable();

                // Поиск по текстовому полю (без учёта регистра)
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var lowerSearchTerm = searchTerm.ToLower();
                    query = query.Where(c =>
                        c.Brand.ToLower().Contains(lowerSearchTerm) ||
                        c.Model.ToLower().Contains(lowerSearchTerm) ||
                        (c.StateMark != null && c.StateMark.ToLower().Contains(lowerSearchTerm)) ||
                        (c.VinNumber != null && c.VinNumber.ToLower().Contains(lowerSearchTerm)) ||
                        (c.Color != null && c.Color.ToLower().Contains(lowerSearchTerm)) ||
                        (c.ProductionYear.HasValue && c.ProductionYear.Value.ToString().Contains(searchTerm)));
                }

                var cars = await query.OrderByDescending(c => c.CreatedAt).ToListAsync();

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
                ShowErrorStatus($"Ошибка фильтрации автомобилей: {ex.Message}");
            }
        }

        private async Task LoadFilteredClientsAsync()
        {
            try
            {
                var searchTerm = textBoxClientsFilterSearch.Text.Trim();

                // Получаем тип клиента из ComboBox
                ClientType? type = null;
                if (comboBoxClientsTypeFilter.SelectedIndex > 0)
                {
                    type = comboBoxClientsTypeFilter.SelectedIndex switch
                    {
                        1 => ClientType.Individual,
                        2 => ClientType.Legal,
                        _ => null
                    };
                }

                // Создаём отдельный контекст для фильтрации клиентов
                var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                    .UseNpgsql(Settings.DBConfig.ConnectionString)
                    .Options;

                using var dbContext = new AutoserviceDbContext(optionsBuilder);

                var query = dbContext.Clients
                    .Where(c => c.IsActive)
                    .AsQueryable();

                // Поиск по текстовому полю (без учёта регистра)
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var lowerSearchTerm = searchTerm.ToLower();
                    query = query.Where(c =>
                        c.LastName.ToLower().Contains(lowerSearchTerm) ||
                        c.FirstName.ToLower().Contains(lowerSearchTerm) ||
                        (c.MiddleName != null && c.MiddleName.ToLower().Contains(lowerSearchTerm)) ||
                        c.Phone.Contains(searchTerm) ||
                        (c.Email != null && c.Email.ToLower().Contains(lowerSearchTerm)) ||
                        (c.Address != null && c.Address.ToLower().Contains(lowerSearchTerm)) ||
                        (c.Inn != null && c.Inn.ToLower().Contains(lowerSearchTerm)));
                }

                // Фильтр по типу клиента
                if (type.HasValue)
                {
                    query = query.Where(c => c.Type == type.Value);
                }

                var clients = await query.OrderBy(c => c.LastName).ToListAsync();

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
                ShowErrorStatus($"Ошибка фильтрации клиентов: {ex.Message}");
            }
        }

        #endregion

        #region Search Handlers

        private async void buttonOrdersFiltersSearchSubmit_Click(object sender, EventArgs e)
        {
            await LoadFilteredOrdersAsync();
        }

        private async void buttonCarsFiltersSearchSubmit_Click(object sender, EventArgs e)
        {
            await LoadFilteredCarsAsync();
        }

        private async void buttonClientsFiltersSearchSubmit_Click(object sender, EventArgs e)
        {
            await LoadFilteredClientsAsync();
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
