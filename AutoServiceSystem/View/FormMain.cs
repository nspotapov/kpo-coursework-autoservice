
namespace View
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            SetTitle("Иванов А.А. (Менеджер)");
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string version = ThisAssembly.Git.Tag;

            if (string.IsNullOrEmpty(version))
            {
                version = ThisAssembly.Git.Commit;
            }

            MessageBox.Show(
                $"Информационная система: Автосервис\n" +
                $"Версия: {version}\n" +
                $"Дата релиза: {ThisAssembly.Git.CommitDate}\n" +
                $"Автор: Потапов Н.С.",
                "Информация о программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ClearStatusLabel()
        {
            SetStatusLabel(string.Empty, DefaultForeColor);
        }

        private void SetStatusLabel(string text, Color color)
        {
            toolStripStatusLabel.Text = text;
            toolStripStatusLabel.ForeColor = color;
        }

        private void ShowErrorStatus(string text)
        {
            SetStatusLabel("Ошибка! " + text, Color.Red);
        }

        private void ShowInfoStatus(string text)
        {
            SetStatusLabel(text, DefaultForeColor);
        }

        private void SetTitle(string text)
        {
            Text = Settings.GlobalConstants.AppName + (string.IsNullOrEmpty(text) ? string.Empty : (" " + text));
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ClearStatusLabel();
            PrepareOrdersFilters();
            PrepareClientsFilters();
            // TODO: Загрузка данных
        }

        private static DateTime GetWeekStartDate(DateTime date, System.Globalization.CultureInfo cultureInfo)
        {
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            return date.AddDays((Int32)firstDayOfWeek - (Int32)date.DayOfWeek);
        }

        private static DateTime GetWeekStartDate(DateTime date)
        {
            return GetWeekStartDate(date, Thread.CurrentThread.CurrentCulture);
        }

        private static DateTime GetCurrentWeekStartDate()
        {
            return GetWeekStartDate(DateTime.Now.Date);
        }

        private void PrepareOrdersFilters()
        {
            var currentWeekStartDate = GetCurrentWeekStartDate();

            dateTimePickerOrderFilterDateFrom.Value = currentWeekStartDate;
            dateTimePickerOrderFilterDateTo.Value = currentWeekStartDate.AddDays(13);

            comboBoxOrderFilterStatus.SelectedIndex = 0;
            comboBoxOrderFilterWorker.SelectedIndex = 0;
        }

        private void PrepareClientsFilters()
        {
            comboBoxClientsTypeFilter.SelectedIndex = 0;
        }

        private void CreateItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Проверять на какой вкладке находится пользователь и открывать окно создания соответствующего элемента
        }

        private void EditItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Проверять, что элемент списка выбран и открывать окно редактирования элемента
        }

        private void dateTimePickerOrderFilterDateFrom_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void dateTimePickerOrderFilterDateTo_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void comboBoxOrderFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void comboBoxOrderFilterWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации
        }

        private void textBoxOrderFilterSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат фильтрации + поиск
        }

        private void textBoxCarsSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат поиска
        }

        private void textBoxClientsSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат поиска
        }

        private void comboBoxClientsTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Обновлять результат поиска
        }

        private void SystemUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Открыть окно управления списком системных пользователей
        }

        private void buttonOrdersFiltersSubmit_Click(object sender, EventArgs e)
        {
            // TODO: Применить фильтры на вкладке заказ-нарядов
        }

        private void buttonCarsFiltersSubmit_Click(object sender, EventArgs e)
        {
            // TODO: Применить фильтры на вкладке автомобилей
        }

        private void buttonClientsFiltersSubmit_Click(object sender, EventArgs e)
        {
            // TODO: Применить фильтры на вкладке клиентов
        }

        private void FocusOnSearchFieldOnCurrentTab()
        {
            if (tabControl.SelectedTab == tabPageOrders)
            {
                textBoxOrderFilterSearch.Focus();
            }
            else if (tabControl.SelectedTab == tabPageCars)
            {
                textBoxCarsFilterSearch.Focus();
            }
            else if (tabControl.SelectedTab == tabPageClients)
            {
                textBoxClientsFilterSearch.Focus();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                FocusOnSearchFieldOnCurrentTab();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D1))
            {
                tabControl.SelectTab(tabPageOrders);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D2))
            {
                tabControl.SelectTab(tabPageCars);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D3))
            {
                tabControl.SelectTab(tabPageClients);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
