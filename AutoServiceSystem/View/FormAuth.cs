namespace View
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();

            toolStripStatusLabel.ForeColor = Color.Red;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // TODO: Реализовать механизм аутентификации и авторизации

            if (textBoxUsername.Text == "admin" && textBoxPassword.Text == "admin")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                SetStatusLabel("Неверное имя пользователя или пароль");
            }
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            ClearStatusLabel();
        }

        private void ClearStatusLabel()
        {
            SetStatusLabel(string.Empty);
        }

        private void SetStatusLabel(string text)
        {
            toolStripStatusLabel.Text = text;
        }
    }
}
