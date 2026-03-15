using Data;
using Data.Models;
using Data.Repositories;
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

            comboBoxStatus.SelectedIndex = 0; // По умолчанию "Ожидает"

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
                dateTimePickerServiceDateTime.Value = DateTime.Now.AddHours(1);
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
                await LoadCarsForClient(order.ClientId);
                comboBoxCar.SelectedValue = order.CarId;
                
                if (order.MasterId.HasValue)
                {
                    comboBoxMaster.SelectedValue = order.MasterId.Value;
                }
                
                dateTimePickerServiceDateTime.Value = order.ServiceDateTime;
                
                var statusIndex = order.Status switch
                {
                    OrderStatus.Pending => 0,
                    OrderStatus.InProgress => 1,
                    OrderStatus.Completed => 2,
                    OrderStatus.Overdue => 3,
                    OrderStatus.Cancelled => 4,
                    _ => 0
                };
                comboBoxStatus.SelectedIndex = statusIndex;

                _selectedServices = order.OrderServices.ToList();
                _selectedParts = order.OrderParts.ToList();

                RefreshServicesGrid();
                RefreshPartsGrid();
                UpdateTotals();
            }
        }

        private async Task LoadCarsForClient(int clientId)
        {
            // Получаем автомобили клиента через OwnerId
            var clientCars = await _dbContext.Cars
                .Where(c => c.OwnerId == clientId)
                .ToListAsync();
            
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
            if (comboBoxClient.SelectedValue is int clientId && clientId > 0)
            {
                _ = LoadCarsForClient(clientId);
            }
        }

        private void dateTimePickerServiceDateTime_ValueChanged(object sender, EventArgs e)
        {
            // Можно добавить проверку доступности мастера
        }

        private async void buttonShowSchedule_Click(object sender, EventArgs e)
        {
            // Получаем выбранную дату
            var selectedDate = dateTimePickerServiceDateTime.Value.Date;

            // Загружаем активных мастеров
            var masters = await _dbContext.Masters.Where(m => m.IsActive).ToListAsync();

            if (masters.Count == 0)
            {
                MessageBox.Show("Нет доступных мастеров.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Показываем форму расписания
            var scheduleForm = new FormMasterSchedule(masters, selectedDate);
            if (scheduleForm.ShowDialog() == DialogResult.OK)
            {
                if (scheduleForm.SelectedMaster != null && scheduleForm.SelectedDateTime.HasValue)
                {
                    // Устанавливаем выбранного мастера и время
                    comboBoxMaster.SelectedValue = scheduleForm.SelectedMaster.Id;
                    dateTimePickerServiceDateTime.Value = scheduleForm.SelectedDateTime.Value;
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

            try
            {
                var status = comboBoxStatus.SelectedIndex switch
                {
                    0 => OrderStatus.Pending,
                    1 => OrderStatus.InProgress,
                    2 => OrderStatus.Completed,
                    3 => OrderStatus.Overdue,
                    4 => OrderStatus.Cancelled,
                    _ => OrderStatus.Pending
                };

                var masterId = Convert.ToInt32(comboBoxMaster.SelectedValue);
                // Явно указываем DateTimeKind.Utc для корректной работы с PostgreSQL
                var serviceDateTime = DateTime.SpecifyKind(dateTimePickerServiceDateTime.Value, DateTimeKind.Utc);

                if (OrderId.HasValue)
                {
                    // Редактирование
                    var order = await _orderRepository.GetByIdAsync(OrderId.Value);
                    if (order != null)
                    {
                        order.ClientId = Convert.ToInt32(comboBoxClient.SelectedValue);
                        order.CarId = Convert.ToInt32(comboBoxCar.SelectedValue);
                        order.MasterId = masterId;
                        order.ServiceDateTime = serviceDateTime;
                        order.Status = status;

                        // Обновляем услуги и запчасти
                        _dbContext.OrderServices.RemoveRange(order.OrderServices);
                        _dbContext.OrderParts.RemoveRange(order.OrderParts);
                        
                        foreach (var os in _selectedServices)
                        {
                            os.OrderId = order.Id;
                            _dbContext.OrderServices.Add(os);
                        }
                        
                        foreach (var op in _selectedParts)
                        {
                            op.OrderId = order.Id;
                            _dbContext.OrderParts.Add(op);
                        }

                        order.TotalPrice = _selectedServices.Sum(s => s.Price * s.Quantity) + 
                                          _selectedParts.Sum(p => p.Price * p.Quantity);

                        await _dbContext.SaveChangesAsync();
                        MessageBox.Show("Заявка обновлена", "Успешно", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        Status = status,
                        ManagerId = CurrentUser.User?.Id ?? 1,
                        TotalPrice = _selectedServices.Sum(s => s.Price * s.Quantity) + 
                                    _selectedParts.Sum(p => p.Price * p.Quantity)
                    };

                    await _orderRepository.CreateAsync(order);

                    // Добавляем услуги и запчасти
                    foreach (var os in _selectedServices)
                    {
                        os.OrderId = order.Id;
                        _dbContext.OrderServices.Add(os);
                    }

                    foreach (var op in _selectedParts)
                    {
                        op.OrderId = order.Id;
                        _dbContext.OrderParts.Add(op);
                    }

                    await _dbContext.SaveChangesAsync();
                    MessageBox.Show("Заявка создана", "Успешно", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", 
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
                await LoadCarsForClient(clientId);
                
                // Выбираем newly созданный автомобиль
                if (formCar.CarId.HasValue)
                {
                    comboBoxCar.SelectedValue = formCar.CarId.Value;
                }
            }
        }
    }
}
