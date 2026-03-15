using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace View
{
    public partial class FormCar : Form
    {
        public int? CarId { get; set; }
        public int? ClientId { get; set; } // Для привязки к клиенту при создании

        private readonly AutoserviceDbContext _dbContext;
        private readonly CarRepository _carRepository;
        private readonly ClientRepository _clientRepository;

        public FormCar()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _carRepository = new CarRepository(_dbContext);
            _clientRepository = new ClientRepository(_dbContext);
        }

        /// <summary>
        /// Конструктор для создания автомобиля с привязкой к клиенту
        /// </summary>
        public FormCar(Client client) : this()
        {
            ClientId = client.Id;
            Text = $"Создание автомобиля для клиента {client.FullName}";
        }

        private async Task InitializeComboBoxesAsync()
        {
            // Загружаем список клиентов для выбора
            var clients = await _clientRepository.GetAllAsync();
            comboBoxCarClient.DataSource = clients;
            comboBoxCarClient.DisplayMember = "FullName";
            comboBoxCarClient.ValueMember = "Id";
            comboBoxCarClient.SelectedIndex = -1;
        }

        private async void FormCar_Load(object sender, EventArgs e)
        {
            // Сначала инициализируем комбобокс
            await InitializeComboBoxesAsync();
            
            if (CarId.HasValue)
            {
                Text = "Редактирование автомобиля";
                await LoadCarAsync(CarId.Value);
            }
            else
            {
                Text = "Создание автомобиля";
            }
        }

        private async Task LoadCarAsync(int carId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            if (car != null)
            {
                comboBoxCarBrand.Text = car.Brand;
                comboBoxCarModel.Text = car.Model;
                maskedTextBoxCarStateMark.Text = car.StateMark ?? string.Empty;

                if (car.ProductionYear.HasValue)
                {
                    maskedTextBoxCarProductionYear.Text = car.ProductionYear.Value.ToString();
                }

                comboBoxCarColor.Text = car.Color ?? string.Empty;
                maskedTextBoxCarVinNumber.Text = car.VinNumber ?? string.Empty;

                // Устанавливаем владельца только если DataSource уже установлен
                if (car.OwnerId.HasValue && comboBoxCarClient.DataSource != null)
                {
                    // Проверяем, что клиент с таким ID есть в списке
                    var clients = comboBoxCarClient.DataSource as List<Client>;
                    if (clients != null && clients.Any(c => c.Id == car.OwnerId.Value))
                    {
                        comboBoxCarClient.SelectedValue = car.OwnerId.Value;
                    }
                }
            }
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            var brand = comboBoxCarBrand.Text.Trim();
            var model = comboBoxCarModel.Text.Trim();
            var stateMark = maskedTextBoxCarStateMark.Text.Trim();
            var productionYearText = maskedTextBoxCarProductionYear.Text.Trim();
            var color = comboBoxCarColor.Text.Trim();
            var vinNumber = maskedTextBoxCarVinNumber.Text.Trim();
            
            // Получаем ClientId из комбобокса
            int? ownerId = comboBoxCarClient.SelectedValue as int?;

            if (string.IsNullOrWhiteSpace(brand))
            {
                MessageBox.Show("Введите марку автомобиля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                MessageBox.Show("Введите модель автомобиля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? productionYear = null;
            if (!string.IsNullOrWhiteSpace(productionYearText) && int.TryParse(productionYearText, out int year))
            {
                productionYear = year;
            }

            try
            {
                if (CarId.HasValue)
                {
                    // Редактирование
                    var car = await _carRepository.GetByIdAsync(CarId.Value);
                    if (car != null)
                    {
                        car.Brand = brand;
                        car.Model = model;
                        car.StateMark = string.IsNullOrWhiteSpace(stateMark) ? null : stateMark;
                        car.ProductionYear = productionYear;
                        car.Color = string.IsNullOrWhiteSpace(color) ? null : color;
                        car.VinNumber = string.IsNullOrWhiteSpace(vinNumber) ? null : vinNumber;
                        car.OwnerId = ownerId;

                        await _carRepository.UpdateAsync(car);
                        MessageBox.Show("Автомобиль обновлен", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Создание
                    var car = new Car
                    {
                        OwnerId = ownerId,
                        Brand = brand,
                        Model = model,
                        StateMark = string.IsNullOrWhiteSpace(stateMark) ? null : stateMark,
                        ProductionYear = productionYear,
                        Color = string.IsNullOrWhiteSpace(color) ? null : color,
                        VinNumber = string.IsNullOrWhiteSpace(vinNumber) ? null : vinNumber
                    };

                    await _carRepository.CreateAsync(car);
                    MessageBox.Show("Автомобиль создан", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                // Выводим внутреннюю ошибку БД
                var innerError = dbEx.InnerException?.Message ?? dbEx.Message;
                MessageBox.Show($"Ошибка базы данных: {innerError}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Обработка Enter для переключения между полями
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
                e.Handled = true;
            }
        }
    }
}
