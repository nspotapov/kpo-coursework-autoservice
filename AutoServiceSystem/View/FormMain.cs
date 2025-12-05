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
