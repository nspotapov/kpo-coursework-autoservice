using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormMastersList : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly MasterRepository _masterRepository;

        public FormMastersList()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _masterRepository = new MasterRepository(_dbContext);

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewMasters.Columns.Clear();
            dataGridViewMasters.Columns.Add("Id", "Id");
            dataGridViewMasters.Columns.Add("FullName", "ФИО");
            dataGridViewMasters.Columns.Add("Phone", "Телефон");
            dataGridViewMasters.Columns.Add("Experience", "Стаж (лет)");
            dataGridViewMasters.Columns.Add("IsActive", "Статус");

            dataGridViewMasters.Columns["Id"].Visible = false;
            dataGridViewMasters.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewMasters.Columns["Phone"].Width = 120;
            dataGridViewMasters.Columns["Experience"].Width = 80;
            dataGridViewMasters.Columns["IsActive"].Width = 80;
        }

        private async void FormMastersList_Load(object sender, EventArgs e)
        {
            await LoadMastersAsync();
        }

        private async Task LoadMastersAsync()
        {
            var masters = await _masterRepository.GetAllAsync();

            dataGridViewMasters.Rows.Clear();
            foreach (var master in masters)
            {
                dataGridViewMasters.Rows.Add(
                    master.Id,
                    master.FullName,
                    master.Phone ?? "-",
                    master.ExperienceYears,
                    master.IsActive ? "Активен" : "Не активен"
                );
            }

            labelTotal.Text = $"Всего мастеров: {masters.Count}";
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = new FormMaster();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadMastersAsync();
            }
        }

        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            await EditSelectedMasterAsync();
        }

        private async Task EditSelectedMasterAsync()
        {
            if (dataGridViewMasters.SelectedRows.Count == 1)
            {
                var masterId = Convert.ToInt32(dataGridViewMasters.SelectedRows[0].Cells["Id"].Value);
                var form = new FormMaster { MasterId = masterId };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadMastersAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите мастера для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void dataGridViewMasters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await EditSelectedMasterAsync();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMasters.SelectedRows.Count == 1)
            {
                var masterId = Convert.ToInt32(dataGridViewMasters.SelectedRows[0].Cells["Id"].Value);
                var masterName = dataGridViewMasters.SelectedRows[0].Cells["FullName"].Value.ToString();

                var result = MessageBox.Show($"Деактивировать мастера \"{masterName}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _masterRepository.DeleteAsync(masterId);
                    await LoadMastersAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите мастера для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
