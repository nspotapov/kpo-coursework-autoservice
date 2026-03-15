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

                form.ShowDialog();
                await LoadOrdersAsync();
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

                form.ShowDialog();
                await LoadCarsAsync();
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

                form.ShowDialog();
                await LoadClientsAsync();
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
                var orders = await _orderRepository.GetAllAsync();
                
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
    }
}
