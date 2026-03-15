using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormServicesList : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly ServiceRepository _serviceRepository;

        public FormServicesList()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _serviceRepository = new ServiceRepository(_dbContext);

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewServices.Columns.Clear();
            dataGridViewServices.Columns.Add("Id", "Id");
            dataGridViewServices.Columns.Add("Name", "Наименование");
            dataGridViewServices.Columns.Add("Description", "Описание");
            dataGridViewServices.Columns.Add("Price", "Цена");
            dataGridViewServices.Columns.Add("Duration", "Длительность");
            
            dataGridViewServices.Columns["Id"].Visible = false;
            dataGridViewServices.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void FormServicesList_Load(object sender, EventArgs e)
        {
            await LoadServicesAsync();
        }

        private async Task LoadServicesAsync()
        {
            var services = await _serviceRepository.GetAllAsync();

            dataGridViewServices.Rows.Clear();
            foreach (var service in services)
            {
                dataGridViewServices.Rows.Add(
                    service.Id,
                    service.Name,
                    service.Description ?? "-",
                    $"{service.Price:C0}",
                    $"{service.DurationMinutes} мин"
                );
            }

            labelTotal.Text = $"Всего услуг: {services.Count}";
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = new FormService();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadServicesAsync();
            }
        }

        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 1)
            {
                var serviceId = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["Id"].Value);
                var form = new FormService { ServiceId = serviceId };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadServicesAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 1)
            {
                var serviceId = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["Id"].Value);
                var serviceName = dataGridViewServices.SelectedRows[0].Cells["Name"].Value.ToString();

                var result = MessageBox.Show($"Деактивировать услугу \"{serviceName}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _serviceRepository.DeleteAsync(serviceId);
                    await LoadServicesAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
