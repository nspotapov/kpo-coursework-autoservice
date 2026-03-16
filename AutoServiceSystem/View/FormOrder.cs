using Data;
using Data.Models;
using Data.Repositories;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormOrder : Form
    {
        public int? OrderId { get; set; }

        private readonly AutoserviceDbContext _dbContext;
        private readonly OrderRepository _orderRepository;
        private readonly ClientRepository _clientRepository;
        private readonly CarRepository _carRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly PartRepository _partRepository;
        private readonly MasterAvailabilityService _availabilityService;

        private List<Client> _allClients = new();
        private List<Car> _allCars = new();
        private List<Service> _allServices = new();
        private List<Part> _allParts = new();
        private List<OrderService> _selectedServices = new();
        private List<OrderPart> _selectedParts = new();

        public FormOrder()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _orderRepository = new OrderRepository(_dbContext);
            _clientRepository = new ClientRepository(_dbContext);
            _carRepository = new CarRepository(_dbContext);
            _serviceRepository = new ServiceRepository(_dbContext);
            _partRepository = new PartRepository(_dbContext);
            _availabilityService = new MasterAvailabilityService(_dbContext);

            InitializeDataGridViews();
        }

        private void InitializeDataGridViews()
        {
            // Настройка DataGridView для услуг
            dataGridViewServices.Columns.Clear();
            dataGridViewServices.Columns.Add("Id", "Id");
            dataGridViewServices.Columns.Add("Name", "Наименование");
            dataGridViewServices.Columns.Add("Price", "Цена");
            dataGridViewServices.Columns.Add("Quantity", "Кол-во");
            dataGridViewServices.Columns.Add("Total", "Сумма");
            dataGridViewServices.Columns["Id"].Visible = false;

            // Настройка DataGridView для запчастей
            dataGridViewParts.Columns.Clear();
            dataGridViewParts.Columns.Add("Id", "Id");
            dataGridViewParts.Columns.Add("Name", "Наименование");
            dataGridViewParts.Columns.Add("Price", "Цена");
            dataGridViewParts.Columns.Add("Quantity", "Кол-во");
            dataGridViewParts.Columns.Add("Total", "Сумма");
            dataGridViewParts.Columns["Id"].Visible = false;
        }

        private async Task InitializeComboBoxesAsync()
        {
            _allClients = await _clientRepository.GetAllAsync();
            _allServices = await _serviceRepository.GetAllAsync();
            _allParts = await _partRepository.GetAllAsync();

            comboBoxClient.DataSource = _allClients;
            comboBoxClient.DisplayMember = "FullName";
            comboBoxClient.ValueMember = "Id";
            comboBoxClient.SelectedIndex = -1;

            // Загружаем мастеров
            var masters = await _dbContext.Masters.Where(m => m.IsActive).ToListAsync();
            comboBoxMaster.DataSource = masters;
            comboBoxMaster.DisplayMember = "FullName";
            comboBoxMaster.ValueMember = "Id";
            comboBoxMaster.SelectedIndex = -1;
        }

        private async void FormOrder_Load(object sender, EventArgs e)
        {
            // Сначала инициализируем комбобоксы
            await InitializeComboBoxesAsync();
            
            await GenerateOrderNumberAsync();

            if (OrderId.HasValue)
            {
                Text = "Редактирование заявки";
                await LoadOrderAsync(OrderId.Value);
            }
            else
            {
                Text = "Создание заявки";
                // Устанавливаем текущую дату и время + 1 час
                dateTimePickerServiceDate.Value = DateTime.Today;
                dateTimePickerServiceTime.Value = DateTime.Now.AddHours(1);
            }
        }

        private async Task GenerateOrderNumberAsync()
        {
            var date = DateTime.Now;
            var orderNumber = $"ORD-{date:yyyyMMdd}-001";
            
            var lastOrder = await _dbContext.Orders
                .OrderByDescending(o => o.OrderNumber)
                .FirstOrDefaultAsync();
            
            if (lastOrder != null && lastOrder.OrderNumber.StartsWith($"ORD-{date:yyyyMMdd}-"))
            {
                var lastNum = int.Parse(lastOrder.OrderNumber.Substring(13));
                orderNumber = $"ORD-{date:yyyyMMdd}-{lastNum + 1:D3}";
            }

            textBoxOrderNumber.Text = orderNumber;
        }

        private async Task LoadOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order != null)
            {
                comboBoxClient.SelectedValue = order.ClientId;
                LoadCarsForClient(order.ClientId);
                comboBoxCar.SelectedValue = order.CarId;

                if (order.MasterId.HasValue)
                {
                    comboBoxMaster.SelectedValue = order.MasterId.Value;
                }

                // Устанавливаем дату и время
                dateTimePickerServiceDate.Value = order.ServiceDateTime.Date;
                dateTimePickerServiceTime.Value = order.ServiceDateTime;

                _selectedServices = order.OrderServices.ToList();
                _selectedParts = order.OrderParts.ToList();

                RefreshServicesGrid();
                RefreshPartsGrid();
                UpdateTotals();
            }
        }

        private void LoadCarsForClient(int clientId)
        {
            // Получаем автомобили клиента через OwnerId (синхронно, чтобы избежать конфликтов)
            var clientCars = _dbContext.Cars
                .Where(c => c.OwnerId == clientId)
                .ToList();

            var bindingList = clientCars.Select(c => new
            {
                c.Id,
                BrandModel = $"{c.Brand} {c.Model} {c.StateMark}"
            }).ToList();

            comboBoxCar.DataSource = bindingList;
            comboBoxCar.DisplayMember = "BrandModel";
            comboBoxCar.ValueMember = "Id";
            comboBoxCar.SelectedIndex = -1;
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбрано корректное значение (int, а не объект Client)
            // Игнорируем событие во время инициализации
            if (comboBoxClient.SelectedValue is int clientId && clientId > 0 && comboBoxClient.DataSource != null)
            {
                LoadCarsForClient(clientId);
            }
        }

        private void dateTimePickerServiceDate_ValueChanged(object sender, EventArgs e)
        {
            // Можно добавить проверку доступности мастера
        }

        private void dateTimePickerServiceTime_ValueChanged(object sender, EventArgs e)
        {
            // Можно добавить проверку доступности мастера
        }

        private async void buttonShowSchedule_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана хотя бы одна услуга
            if (_selectedServices.Count == 0)
            {
                MessageBox.Show(
                    "Сначала добавьте хотя бы одну услугу.\n\n" +
                    "Это необходимо для расчёта длительности и проверки доступности мастеров.",
                    "Услуги не выбраны",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 1; // Переключаем на вкладку услуг
                return;
            }

            // Получаем выбранную дату (конвертируем в UTC)
            var selectedDate = DateTime.SpecifyKind(dateTimePickerServiceDate.Value.Date, DateTimeKind.Utc);

            // Рассчитываем общую длительность услуг
            var totalDuration = _selectedServices.Sum(s => s.Service.DurationMinutes);

            // Загружаем активных мастеров
            var masters = await _dbContext.Masters.Where(m => m.IsActive).ToListAsync();

            if (masters.Count == 0)
            {
                MessageBox.Show("Нет доступных мастеров.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Показываем форму расписания с длительностью услуг
            var scheduleForm = new FormMasterSchedule(masters, selectedDate, totalDuration);
            if (scheduleForm.ShowDialog() == DialogResult.OK)
            {
                if (scheduleForm.SelectedMaster != null && scheduleForm.SelectedDateTime.HasValue)
                {
                    // Устанавливаем выбранного мастера и время
                    comboBoxMaster.SelectedValue = scheduleForm.SelectedMaster.Id;
                    dateTimePickerServiceTime.Value = scheduleForm.SelectedDateTime.Value;
                }
            }
        }

        private async void buttonAddService_Click(object sender, EventArgs e)
        {
            var dialog = new FormServiceSelector(_allServices);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var selectedService = dialog.SelectedService;
                var existingService = _selectedServices.FirstOrDefault(s => s.ServiceId == selectedService.Id);
                
                if (existingService != null)
                {
                    existingService.Quantity++;
                }
                else
                {
                    _selectedServices.Add(new OrderService
                    {
                        ServiceId = selectedService.Id,
                        Service = selectedService,
                        Quantity = 1,
                        Price = selectedService.Price
                    });
                }

                RefreshServicesGrid();
                UpdateTotals();
            }
        }

        private void buttonRemoveService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                var serviceId = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["Id"].Value);
                var serviceToRemove = _selectedServices.FirstOrDefault(s => s.ServiceId == serviceId);
                
                if (serviceToRemove != null)
                {
                    _selectedServices.Remove(serviceToRemove);
                    RefreshServicesGrid();
                    UpdateTotals();
                }
            }
        }

        private async void buttonAddPart_Click(object sender, EventArgs e)
        {
            var dialog = new FormPartSelector(_allParts);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var selectedPart = dialog.SelectedPart;
                var existingPart = _selectedParts.FirstOrDefault(p => p.PartId == selectedPart.Id);
                
                if (existingPart != null)
                {
                    existingPart.Quantity++;
                }
                else
                {
                    _selectedParts.Add(new OrderPart
                    {
                        PartId = selectedPart.Id,
                        Part = selectedPart,
                        Quantity = 1,
                        Price = selectedPart.Price
                    });
                }

                RefreshPartsGrid();
                UpdateTotals();
            }
        }

        private void buttonRemovePart_Click(object sender, EventArgs e)
        {
            if (dataGridViewParts.SelectedRows.Count > 0)
            {
                var partId = Convert.ToInt32(dataGridViewParts.SelectedRows[0].Cells["Id"].Value);
                var partToRemove = _selectedParts.FirstOrDefault(p => p.PartId == partId);
                
                if (partToRemove != null)
                {
                    _selectedParts.Remove(partToRemove);
                    RefreshPartsGrid();
                    UpdateTotals();
                }
            }
        }

        private void RefreshServicesGrid()
        {
            dataGridViewServices.Rows.Clear();
            foreach (var os in _selectedServices)
            {
                var total = os.Price * os.Quantity;
                dataGridViewServices.Rows.Add(
                    os.ServiceId,
                    os.Service.Name,
                    $"{os.Price:C0}",
                    os.Quantity,
                    $"{total:C0}"
                );
            }
            UpdateServicesTotal();
        }

        private void RefreshPartsGrid()
        {
            dataGridViewParts.Rows.Clear();
            foreach (var op in _selectedParts)
            {
                var total = op.Price * op.Quantity;
                dataGridViewParts.Rows.Add(
                    op.PartId,
                    op.Part.Name,
                    $"{op.Price:C0}",
                    op.Quantity,
                    $"{total:C0}"
                );
            }
            UpdatePartsTotal();
        }

        private void UpdateServicesTotal()
        {
            var total = _selectedServices.Sum(s => s.Price * s.Quantity);
            labelServicesTotal.Text = $"Итого услуги: {total:C0}";
        }

        private void UpdatePartsTotal()
        {
            var total = _selectedParts.Sum(p => p.Price * p.Quantity);
            labelPartsTotal.Text = $"Итого запчасти: {total:C0}";
        }

        private void UpdateTotals()
        {
            var servicesTotal = _selectedServices.Sum(s => s.Price * s.Quantity);
            var partsTotal = _selectedParts.Sum(p => p.Price * p.Quantity);
            var grandTotal = servicesTotal + partsTotal;
            
            textBoxTotalPrice.Text = $"{grandTotal:C0}";
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 0;
                return;
            }

            if (comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите автомобиль", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 0;
                return;
            }

            if (comboBoxMaster.SelectedValue == null)
            {
                MessageBox.Show("Выберите мастера", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 0;
                return;
            }

            if (_selectedServices.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одну услугу", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl.SelectedIndex = 1;
                return;
            }

            try
            {
                var masterId = Convert.ToInt32(comboBoxMaster.SelectedValue);

                // Объединяем дату и время
                var serviceDate = dateTimePickerServiceDate.Value.Date;
                var serviceTime = dateTimePickerServiceTime.Value.TimeOfDay;
                var serviceDateTime = serviceDate + serviceTime;

                // Явно указываем DateTimeKind.Utc для корректной работы с PostgreSQL
                serviceDateTime = DateTime.SpecifyKind(serviceDateTime, DateTimeKind.Utc);

                // Проверяем доступность мастера (только для новой заявки или если изменилось время)
                var totalDuration = _selectedServices.Sum(s => s.Service.DurationMinutes);
                var isAvailable = await _availabilityService.IsMasterAvailableAtAsync(
                    masterId, serviceDateTime, totalDuration, OrderId);

                if (!isAvailable)
                {
                    MessageBox.Show(
                        $"Мастер занят в это время!\n\n" +
                        $"Выбранное время: {dateTimePickerServiceDate.Value:dd.MM.yyyy} {dateTimePickerServiceTime.Value:HH:mm}\n" +
                        $"Длительность услуг: {totalDuration} мин.\n\n" +
                        $"Пожалуйста, выберите другое время или мастера.",
                        "Мастер занят",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (OrderId.HasValue)
                {
                    // Редактирование
                    var order = await _dbContext.Orders
                        .Include(o => o.OrderServices)
                        .Include(o => o.OrderParts)
                        .FirstOrDefaultAsync(o => o.Id == OrderId.Value);
                        
                    if (order != null)
                    {
                        order.ClientId = Convert.ToInt32(comboBoxClient.SelectedValue);
                        order.CarId = Convert.ToInt32(comboBoxCar.SelectedValue);
                        order.MasterId = masterId;
                        order.ServiceDateTime = serviceDateTime;
                        order.UpdatedAt = DateTime.UtcNow;
                        // Статус не меняем при редактировании

                        // Обновляем услуги и запчасти
                        _dbContext.OrderServices.RemoveRange(order.OrderServices);
                        _dbContext.OrderParts.RemoveRange(order.OrderParts);

                        // Создаём новые записи услуг с Id = 0 (чтобы EF понял, что это новые записи)
                        foreach (var os in _selectedServices)
                        {
                            _dbContext.OrderServices.Add(new OrderService
                            {
                                OrderId = order.Id,
                                ServiceId = os.ServiceId,
                                Quantity = os.Quantity,
                                Price = os.Price
                            });
                        }

                        // Создаём новые записи запчастей с Id = 0
                        foreach (var op in _selectedParts)
                        {
                            _dbContext.OrderParts.Add(new OrderPart
                            {
                                OrderId = order.Id,
                                PartId = op.PartId,
                                Quantity = op.Quantity,
                                Price = op.Price
                            });
                        }

                        order.TotalPrice = _selectedServices.Sum(s => s.Price * s.Quantity) +
                                          _selectedParts.Sum(p => p.Price * p.Quantity);

                        await _dbContext.SaveChangesAsync();
                        MessageBox.Show("Заявка обновлена", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    // Создание
                    var order = new Order
                    {
                        OrderNumber = textBoxOrderNumber.Text,
                        ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                        CarId = Convert.ToInt32(comboBoxCar.SelectedValue),
                        MasterId = masterId,
                        ServiceDateTime = serviceDateTime,
                        Status = OrderStatus.Pending, // По умолчанию "Ожидает"
                        ManagerId = CurrentUser.User?.Id ?? 1,
                        TotalPrice = _selectedServices.Sum(s => s.Price * s.Quantity) +
                                    _selectedParts.Sum(p => p.Price * p.Quantity)
                    };

                    await _orderRepository.CreateAsync(order);

                    // Добавляем услуги и запчасти (создаём новые записи)
                    foreach (var os in _selectedServices)
                    {
                        _dbContext.OrderServices.Add(new OrderService
                        {
                            OrderId = order.Id,
                            ServiceId = os.ServiceId,
                            Quantity = os.Quantity,
                            Price = os.Price
                        });
                    }

                    foreach (var op in _selectedParts)
                    {
                        _dbContext.OrderParts.Add(new OrderPart
                        {
                            OrderId = order.Id,
                            PartId = op.PartId,
                            Quantity = op.Quantity,
                            Price = op.Price
                        });
                    }

                    await _dbContext.SaveChangesAsync();
                    MessageBox.Show("Заявка создана", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                // Подробная ошибка базы данных
                var errorMsg = $"Ошибка базы данных: {dbEx.Message}\n\n";
                if (dbEx.InnerException != null)
                {
                    errorMsg += $"Внутренняя ошибка: {dbEx.InnerException.Message}\n\n";
                    if (dbEx.InnerException.InnerException != null)
                    {
                        errorMsg += $"Детали: {dbEx.InnerException.InnerException.Message}";
                    }
                }
                
                MessageBox.Show(errorMsg, "Ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var errorMsg = $"Ошибка: {ex.Message}\n\n";
                if (ex.InnerException != null)
                {
                    errorMsg += $"Внутренняя ошибка: {ex.InnerException.Message}\n\n";
                    if (ex.InnerException.InnerException != null)
                    {
                        errorMsg += $"Детали: {ex.InnerException.InnerException.Message}";
                    }
                }
                
                MessageBox.Show(errorMsg, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void buttonAddClient_Click(object sender, EventArgs e)
        {
            // Открываем форму добавления клиента
            var formClient = new FormClient();
            if (formClient.ShowDialog() == DialogResult.OK)
            {
                // Обновляем список клиентов
                _allClients = await _clientRepository.GetAllAsync();
                comboBoxClient.DataSource = null;
                comboBoxClient.DisplayMember = "FullName";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = _allClients;
                comboBoxClient.SelectedIndex = -1;

                // Выбираем newly созданного клиента
                if (formClient.ClientId.HasValue)
                {
                    comboBoxClient.SelectedValue = formClient.ClientId.Value;
                }
            }
        }

        private async void buttonAddCar_Click(object sender, EventArgs e)
        {
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Сначала выберите клиента", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clientId = Convert.ToInt32(comboBoxClient.SelectedValue);
            var client = _allClients.FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                MessageBox.Show("Клиент не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Открываем форму добавления автомобиля с предвыбранным клиентом
            var formCar = new FormCar(client);
            if (formCar.ShowDialog() == DialogResult.OK)
            {
                // Обновляем список автомобилей
                LoadCarsForClient(clientId);

                // Выбираем newly созданный автомобиль
                if (formCar.CarId.HasValue)
                {
                    comboBoxCar.SelectedValue = formCar.CarId.Value;
                }
            }
        }

        /// <summary>
        /// Отмена заявки
        /// </summary>
        private async void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            if (!OrderId.HasValue)
            {
                MessageBox.Show("Сначала сохраните заявку", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Вы действительно хотите отменить заявку?\n\nЭто действие нельзя отменить.",
                "Отмена заявки",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var order = await _orderRepository.GetByIdAsync(OrderId.Value);
                    if (order != null)
                    {
                        order.Status = OrderStatus.Cancelled;
                        order.UpdatedAt = DateTime.UtcNow;
                        await _dbContext.SaveChangesAsync();

                        MessageBox.Show("Заявка отменена", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Пользователь отменил - не закрываем форму
                return;
            }
        }

        /// <summary>
        /// Начать выполнение заявки
        /// </summary>
        private async void buttonStartExecution_Click(object sender, EventArgs e)
        {
            if (!OrderId.HasValue)
            {
                MessageBox.Show("Сначала сохраните заявку", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var order = await _orderRepository.GetByIdAsync(OrderId.Value);
                if (order != null)
                {
                    if (order.Status == OrderStatus.Cancelled)
                    {
                        MessageBox.Show("Нельзя начать выполнение отменённой заявки", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (order.Status == OrderStatus.Completed)
                    {
                        MessageBox.Show("Заявка уже выполнена", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    order.Status = OrderStatus.InProgress;
                    order.UpdatedAt = DateTime.UtcNow;
                    await _dbContext.SaveChangesAsync();

                    MessageBox.Show("Заявка переведена в статус \"В работе\"", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создать чек из заявки
        /// </summary>
        private void buttonCreateCheck_Click(object sender, EventArgs e)
        {
            if (!OrderId.HasValue)
            {
                MessageBox.Show("Сначала сохраните заявку", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Открываем форму создания чека с текущей заявкой
                var formCheck = new FormCheck(OrderId.Value);
                if (formCheck.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Чек создан. Заявка переведена в статус \"Выполнена\"", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
