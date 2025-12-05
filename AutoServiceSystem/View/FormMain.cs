namespace View
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Вывод информации о программе
            MessageBox.Show(
                $"Информационная система: Автосервис\n" +
                $"Версия: {ThisAssembly.Git.Commit}\n" +
                $"Автор: Потапов Н.С.",
                "Информация о программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private void ClearStatusLabel()
        {
            SetStatusLabel(string.Empty, Control.DefaultForeColor);
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
            SetStatusLabel(text, Control.DefaultForeColor);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ClearStatusLabel();
            // TODO: Загрузка данных
        }
    }
}
