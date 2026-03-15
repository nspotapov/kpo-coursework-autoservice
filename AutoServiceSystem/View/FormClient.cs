using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormClient : Form
    {
        public int? ClientId { get; set; }

        private readonly AutoserviceDbContext _dbContext;
        private readonly ClientRepository _clientRepository;

        public FormClient()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _clientRepository = new ClientRepository(_dbContext);

            comboBoxType.SelectedIndex = 0; // По умолчанию физ. лицо
        }

        private async void FormClient_Load(object sender, EventArgs e)
        {
            if (ClientId.HasValue)
            {
                Text = "Редактирование клиента";
                await LoadClientAsync(ClientId.Value);
            }
            else
            {
                Text = "Создание клиента";
            }
        }

        private async Task LoadClientAsync(int clientId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client != null)
            {
                ClientId = client.Id; // Сохраняем ID
                comboBoxType.SelectedIndex = client.Type == ClientType.Individual ? 0 : 1;
                textBoxLastName.Text = client.LastName;
                textBoxFirstName.Text = client.FirstName;
                textBoxMiddleName.Text = client.MiddleName ?? string.Empty;
                maskedTextBoxPhone.Text = client.Phone;
                textBoxEmail.Text = client.Email ?? string.Empty;
                textBoxAddress.Text = client.Address ?? string.Empty;
                textBoxInn.Text = client.Inn ?? string.Empty;
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обновление меток в зависимости от типа клиента
            if (comboBoxType.SelectedIndex == 0)
            {
                labelLastName.Text = "Фамилия *";
                labelFirstName.Text = "Имя *";
                labelInn.Text = "ИНН (необязательно)";
            }
            else
            {
                labelLastName.Text = "Название организации *";
                labelFirstName.Text = "Контактное лицо *";
                labelInn.Text = "ИНН *";
            }
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            var type = comboBoxType.SelectedIndex == 0 ? ClientType.Individual : ClientType.Legal;
            var lastName = textBoxLastName.Text.Trim();
            var firstName = textBoxFirstName.Text.Trim();
            var middleName = textBoxMiddleName.Text.Trim();
            var phone = maskedTextBoxPhone.Text.Trim();
            var email = textBoxEmail.Text.Trim();
            var address = textBoxAddress.Text.Trim();
            var inn = textBoxInn.Text.Trim();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Введите фамилию / название организации", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Введите имя / контактное лицо", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Введите телефон", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (type == ClientType.Legal && string.IsNullOrWhiteSpace(inn))
            {
                MessageBox.Show("Для юридического лица ИНН обязателен", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (ClientId.HasValue)
                {
                    // Редактирование
                    var client = await _clientRepository.GetByIdAsync(ClientId.Value);
                    if (client != null)
                    {
                        client.Type = type;
                        client.LastName = lastName;
                        client.FirstName = firstName;
                        client.MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName;
                        client.Phone = phone;
                        client.Email = string.IsNullOrWhiteSpace(email) ? null : email;
                        client.Address = string.IsNullOrWhiteSpace(address) ? null : address;
                        client.Inn = string.IsNullOrWhiteSpace(inn) ? null : inn;

                        await _clientRepository.UpdateAsync(client);
                        MessageBox.Show("Клиент обновлен", "Успешно", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Создание
                    var client = new Client
                    {
                        Type = type,
                        LastName = lastName,
                        FirstName = firstName,
                        MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName,
                        Phone = phone,
                        Email = string.IsNullOrWhiteSpace(email) ? null : email,
                        Address = string.IsNullOrWhiteSpace(address) ? null : address,
                        Inn = string.IsNullOrWhiteSpace(inn) ? null : inn
                    };

                    await _clientRepository.CreateAsync(client);
                    MessageBox.Show("Клиент создан", "Успешно", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    ClientId = client.Id; // Сохраняем ID для добавления автомобиля
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
                MessageBox.Show(errorMsg, "Ошибка", 
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
