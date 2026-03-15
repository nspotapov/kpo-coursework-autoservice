using Data.Models;

namespace View
{
    /// <summary>
    /// Форма выбора услуги
    /// </summary>
    public partial class FormServiceSelector : Form
    {
        public Service? SelectedService { get; private set; }

        public FormServiceSelector(List<Service> services)
        {
            InitializeComponent();
            
            // Настройка DataGridView
            dataGridViewServices.Columns.Clear();
            dataGridViewServices.Columns.Add("Name", "Наименование");
            dataGridViewServices.Columns.Add("Price", "Цена");
            dataGridViewServices.Columns.Add("Duration", "Длительность (мин)");
            dataGridViewServices.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Заполнение данными
            foreach (var service in services)
            {
                dataGridViewServices.Rows.Add(
                    service.Name,
                    $"{service.Price:C0}",
                    service.DurationMinutes
                );
            }

            // Сохраняем список для доступа по индексу
            Tag = services;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                var services = (List<Service>)Tag!;
                var selectedIndex = dataGridViewServices.SelectedRows[0].Index;
                SelectedService = services[selectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите услугу", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dataGridViewServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonOK_Click(sender, e);
            }
        }
    }
}
