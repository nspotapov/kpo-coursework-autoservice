using Data.Models;

namespace View
{
    /// <summary>
    /// Форма выбора запчасти
    /// </summary>
    public partial class FormPartSelector : Form
    {
        public Part? SelectedPart { get; private set; }

        public FormPartSelector(List<Part> parts)
        {
            InitializeComponent();
            
            // Настройка DataGridView
            dataGridViewParts.Columns.Clear();
            dataGridViewParts.Columns.Add("Name", "Наименование");
            dataGridViewParts.Columns.Add("Article", "Артикул");
            dataGridViewParts.Columns.Add("Price", "Цена");
            dataGridViewParts.Columns.Add("Quantity", "На складе");
            dataGridViewParts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Заполнение данными
            foreach (var part in parts)
            {
                dataGridViewParts.Rows.Add(
                    part.Name,
                    part.Article ?? "-",
                    $"{part.Price:C0}",
                    part.QuantityInStock
                );
            }

            // Сохраняем список для доступа по индексу
            Tag = parts;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (dataGridViewParts.SelectedRows.Count > 0)
            {
                var parts = (List<Part>)Tag!;
                var selectedIndex = dataGridViewParts.SelectedRows[0].Index;
                SelectedPart = parts[selectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите запчасть", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dataGridViewParts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonOK_Click(sender, e);
            }
        }
    }
}
