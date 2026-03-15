using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormService : Form
    {
        public int? ServiceId { get; set; }

        private readonly AutoserviceDbContext _dbContext;
        private readonly ServiceRepository _serviceRepository;

        public FormService()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _serviceRepository = new ServiceRepository(_dbContext);
        }

        private async void FormService_Load(object sender, EventArgs e)
        {
            if (ServiceId.HasValue)
            {
                Text = "Редактирование услуги";
                await LoadServiceAsync(ServiceId.Value);
            }
            else
            {
                Text = "Создание услуги";
            }
        }

        private async Task LoadServiceAsync(int serviceId)
        {
            var service = await _serviceRepository.GetByIdAsync(serviceId);
            if (service != null)
            {
                textBoxName.Text = service.Name;
                textBoxDescription.Text = service.Description ?? string.Empty;
                numericUpDownPrice.Value = service.Price;
                numericUpDownDuration.Value = service.DurationMinutes;
            }
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text.Trim();
            var description = textBoxDescription.Text.Trim();
            var price = numericUpDownPrice.Value;
            var duration = (int)numericUpDownDuration.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите наименование услуги", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (ServiceId.HasValue)
                {
                    // Редактирование
                    var service = await _serviceRepository.GetByIdAsync(ServiceId.Value);
                    if (service != null)
                    {
                        service.Name = name;
                        service.Description = string.IsNullOrWhiteSpace(description) ? null : description;
                        service.Price = price;
                        service.DurationMinutes = duration;

                        await _serviceRepository.UpdateAsync(service);
                        MessageBox.Show("Услуга обновлена", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Создание
                    var service = new Service
                    {
                        Name = name,
                        Description = string.IsNullOrWhiteSpace(description) ? null : description,
                        Price = price,
                        DurationMinutes = duration
                    };

                    await _serviceRepository.CreateAsync(service);
                    MessageBox.Show("Услуга создана", "Успешно",
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
    }
}
