using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormCar : Form
    {
        public int? CarId { get; set; }
        public int? ClientId { get; set; } // Для привязки к клиенту при создании

        private readonly AutoserviceDbContext _dbContext;
        private readonly CarRepository _carRepository;

        public FormCar()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _carRepository = new CarRepository(_dbContext);

            InitializeComboBoxes();
        }

        private async void InitializeComboBoxes()
        {
            // Загружаем все автомобили для выбора (если нужно привязывать к клиенту)
            // Но в этой форме просто создаем/редактируем автомобиль
            // Привязка к клиенту будет в форме клиента
        }

        private async void FormCar_Load(object sender, EventArgs e)
        {
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
                        OwnerId = ClientId,
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
