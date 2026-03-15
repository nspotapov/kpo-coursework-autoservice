using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormUsersList : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly UserRepository _userRepository;

        public FormUsersList()
        {
            InitializeComponent();

            // Создаём НОВЫЙ контекст для этой формы
            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _userRepository = new UserRepository(_dbContext);
        }

        private async void FormUsersList_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            dataGridViewUsers.Rows.Clear();
            foreach (var user in users)
            {
                var roleName = user.Role == UserRole.Admin ? "Администратор" : "Менеджер";
                dataGridViewUsers.Rows.Add(
                    user.Id,
                    user.Username,
                    user.FullName,
                    roleName,
                    user.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                    user.IsActive ? "Активен" : "Не активен"
                );
            }
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = new FormUser();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadUsersAsync();
            }
        }

        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            await EditSelectedUserAsync();
        }

        private async Task EditSelectedUserAsync()
        {
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                var userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["ColumnUserId"].Value);
                var form = new FormUser { UserId = userId };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadUsersAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void dataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Редактирование по двойному клику (пропускаем заголовок)
            if (e.RowIndex >= 0)
            {
                await EditSelectedUserAsync();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 1)
            {
                var userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["ColumnUserId"].Value);
                var username = dataGridViewUsers.SelectedRows[0].Cells["ColumnUsername"].Value.ToString();

                if (username == "admin")
                {
                    MessageBox.Show("Нельзя удалить основного администратора", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show($"Деактивировать пользователя \"{username}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _userRepository.DeleteUserAsync(userId);
                    await LoadUsersAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
