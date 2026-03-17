using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormAuth : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly UserRepository _userRepository;

        public FormAuth()
        {
            InitializeComponent();

            toolStripStatusLabel.ForeColor = Color.Red;

            // Инициализация контекста БД
            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _userRepository = new UserRepository(_dbContext);
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text.Trim();
            var password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                SetStatusLabel("Введите имя пользователя");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                SetStatusLabel("Введите пароль");
                return;
            }

            buttonSubmit.Enabled = false;
            SetStatusLabel("Проверка учетных данных...");

            try
            {
                var user = await _userRepository.AuthenticateAsync(username, password);

                if (user != null)
                {
                    CurrentUser.Login(user);
                    DialogResult = DialogResult.OK;
                    Close(); // Закрываем форму авторизации
                }
                else
                {
                    SetStatusLabel("Неверное имя пользователя или пароль");
                    buttonSubmit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                SetStatusLabel($"Ошибка подключения к БД: {ex.Message}");
                buttonSubmit.Enabled = true;
            }
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            ClearStatusLabel();
            
            // Значения по умолчанию для тестирования
            textBoxUsername.Text = "admin";
            textBoxPassword.Text = "admin";
            
            textBoxUsername.Focus();
            textBoxPassword.SelectAll();
        }

        private void ClearStatusLabel()
        {
            SetStatusLabel(string.Empty);
        }

        private void SetStatusLabel(string text)
        {
            toolStripStatusLabel.Text = text;
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSubmit_Click(sender, e);
            }
        }

        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBoxPassword.Focus();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                // Если пользователь закрыл форму без авторизации
                Application.Exit();
            }
            base.OnFormClosing(e);
        }
    }
}
