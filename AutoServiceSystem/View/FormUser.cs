using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormUser : Form
    {
        public int? UserId { get; set; }

        private readonly AutoserviceDbContext _dbContext;
        private readonly UserRepository _userRepository;

        public FormUser()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _userRepository = new UserRepository(_dbContext);

            comboBoxRole.SelectedIndex = 1; // По умолчанию менеджер
        }

        private async void FormUser_Load(object sender, EventArgs e)
        {
            if (UserId.HasValue)
            {
                Text = "Редактирование пользователя";
                await LoadUserAsync(UserId.Value);
            }
            else
            {
                Text = "Создание пользователя";
            }
        }

        private async Task LoadUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                UserId = user.Id; // Сохраняем ID для последующего редактирования
                textBoxUsername.Text = user.Username;
                textBoxLastName.Text = user.LastName;
                textBoxFirstName.Text = user.FirstName;
                textBoxMiddleName.Text = user.MiddleName ?? string.Empty;
                maskedTextBoxPhone.Text = user.Phone ?? string.Empty;

                if (user.BirthDate.HasValue)
                {
                    // Конвертируем UTC в локальное время для отображения
                    var localDate = user.BirthDate.Value.ToLocalTime().Date;
                    dateTimePickerBirthDate.Value = localDate;
                    dateTimePickerBirthDate.Checked = true;
                }
                else
                {
                    dateTimePickerBirthDate.Checked = false;
                }

                comboBoxRole.SelectedIndex = user.Role == UserRole.Admin ? 0 : 1;
                textBoxPassword.PlaceholderText = "Оставьте пустым, чтобы не изменять";
            }
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text.Trim();
            var password = textBoxPassword.Text;
            var lastName = textBoxLastName.Text.Trim();
            var firstName = textBoxFirstName.Text.Trim();
            var middleName = textBoxMiddleName.Text.Trim();
            var phone = maskedTextBoxPhone.Text.Trim();
            var role = comboBoxRole.SelectedIndex == 0 ? UserRole.Admin : UserRole.Manager;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Явная валидация роли
            if (comboBoxRole.SelectedIndex < 0 || comboBoxRole.SelectedIndex > 1)
            {
                MessageBox.Show("Выберите роль (admin или manager)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка уникальности username
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && (!UserId.HasValue || u.Id != UserId.Value));
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DateTime? birthDate = null;
                if (dateTimePickerBirthDate.Checked && dateTimePickerBirthDate.Value != dateTimePickerBirthDate.MinDate)
                {
                    // Явно создаём DateTime с Kind=Utc для корректной работы с PostgreSQL
                    var dateValue = dateTimePickerBirthDate.Value;
                    birthDate = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day, 0, 0, 0, DateTimeKind.Utc);
                }

                if (UserId.HasValue)
                {
                    // Редактирование
                    var user = await _dbContext.Users.FindAsync(UserId.Value);
                    if (user != null)
                    {
                        user.Username = username;
                        user.LastName = lastName;
                        user.FirstName = firstName;
                        user.MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName;
                        user.Phone = string.IsNullOrWhiteSpace(phone) ? null : phone;
                        user.BirthDate = birthDate;
                        user.Role = role;

                        if (!string.IsNullOrWhiteSpace(password))
                        {
                            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                        }

                        await _dbContext.SaveChangesAsync();
                        MessageBox.Show("Пользователь обновлен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Создание
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var user = new User
                    {
                        Username = username,
                        Password = BCrypt.Net.BCrypt.HashPassword(password),
                        LastName = lastName,
                        FirstName = firstName,
                        MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName,
                        Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                        BirthDate = birthDate,
                        Role = role,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    };

                    _dbContext.Users.Add(user);
                    await _dbContext.SaveChangesAsync();

                    MessageBox.Show("Пользователь создан", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                var errorMsg = $"Ошибка: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMsg += $"\n\nВнутренняя ошибка: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
