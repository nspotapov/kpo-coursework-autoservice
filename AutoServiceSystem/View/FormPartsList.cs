using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormPartsList : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly PartRepository _partRepository;

        public FormPartsList()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _partRepository = new PartRepository(_dbContext);

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewParts.Columns.Clear();
            dataGridViewParts.Columns.Add("Id", "Id");
            dataGridViewParts.Columns.Add("Name", "Наименование");
            dataGridViewParts.Columns.Add("Article", "Артикул");
            dataGridViewParts.Columns.Add("Price", "Цена");
            dataGridViewParts.Columns.Add("Quantity", "На складе");
            
            dataGridViewParts.Columns["Id"].Visible = false;
            dataGridViewParts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void FormPartsList_Load(object sender, EventArgs e)
        {
            await LoadPartsAsync();
        }

        private async Task LoadPartsAsync()
        {
            var parts = await _partRepository.GetAllAsync();

            dataGridViewParts.Rows.Clear();
            foreach (var part in parts)
            {
                dataGridViewParts.Rows.Add(
                    part.Id,
                    part.Name,
                    part.Article ?? "-",
                    $"{part.Price:C0}",
                    part.QuantityInStock
                );
            }

            labelTotal.Text = $"Всего запчастей: {parts.Count}";
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = new FormPart();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadPartsAsync();
            }
        }

        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewParts.SelectedRows.Count == 1)
            {
                var partId = Convert.ToInt32(dataGridViewParts.SelectedRows[0].Cells["Id"].Value);
                var form = new FormPart { PartId = partId };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadPartsAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите запчасть для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewParts.SelectedRows.Count == 1)
            {
                var partId = Convert.ToInt32(dataGridViewParts.SelectedRows[0].Cells["Id"].Value);
                var partName = dataGridViewParts.SelectedRows[0].Cells["Name"].Value.ToString();

                var result = MessageBox.Show($"Деактивировать запчасть \"{partName}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _partRepository.DeleteAsync(partId);
                    await LoadPartsAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите запчасть для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
