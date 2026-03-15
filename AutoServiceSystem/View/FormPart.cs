using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormPart : Form
    {
        public int? PartId { get; set; }

        private readonly AutoserviceDbContext _dbContext;
        private readonly PartRepository _partRepository;

        public FormPart()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _partRepository = new PartRepository(_dbContext);
        }

        private async void FormPart_Load(object sender, EventArgs e)
        {
            if (PartId.HasValue)
            {
                Text = "Редактирование запчасти";
                await LoadPartAsync(PartId.Value);
            }
            else
            {
                Text = "Создание запчасти";
            }
        }

        private async Task LoadPartAsync(int partId)
        {
            var part = await _partRepository.GetByIdAsync(partId);
            if (part != null)
            {
                textBoxName.Text = part.Name;
                textBoxArticle.Text = part.Article ?? string.Empty;
                numericUpDownPrice.Value = part.Price;
                numericUpDownQuantity.Value = part.QuantityInStock;
            }
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text.Trim();
            var article = textBoxArticle.Text.Trim();
            var price = numericUpDownPrice.Value;
            var quantity = (int)numericUpDownQuantity.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите наименование запчасти", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (PartId.HasValue)
                {
                    // Редактирование
                    var part = await _partRepository.GetByIdAsync(PartId.Value);
                    if (part != null)
                    {
                        part.Name = name;
                        part.Article = string.IsNullOrWhiteSpace(article) ? null : article;
                        part.Price = price;
                        part.QuantityInStock = quantity;

                        await _partRepository.UpdateAsync(part);
                        MessageBox.Show("Запчасть обновлена", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Создание
                    var part = new Part
                    {
                        Name = name,
                        Article = string.IsNullOrWhiteSpace(article) ? null : article,
                        Price = price,
                        QuantityInStock = quantity
                    };

                    await _partRepository.CreateAsync(part);
                    MessageBox.Show("Запчасть создана", "Успешно",
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
