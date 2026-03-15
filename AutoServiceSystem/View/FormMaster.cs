using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormMaster : Form
    {
        public int? MasterId { get; set; }

        private readonly AutoserviceDbContext _dbContext;
        private readonly MasterRepository _masterRepository;

        public FormMaster()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _masterRepository = new MasterRepository(_dbContext);
        }

        private async void FormMaster_Load(object sender, EventArgs e)
        {
            if (MasterId.HasValue)
            {
                Text = "Редактирование мастера";
                await LoadMasterAsync(MasterId.Value);
            }
            else
            {
                Text = "Создание мастера";
            }
        }

        private async Task LoadMasterAsync(int masterId)
        {
            var master = await _dbContext.Masters.FindAsync(masterId);
            if (master != null)
            {
                MasterId = master.Id;
                textBoxLastName.Text = master.LastName;
                textBoxFirstName.Text = master.FirstName;
                textBoxMiddleName.Text = master.MiddleName ?? string.Empty;
                maskedTextBoxPhone.Text = master.Phone ?? string.Empty;
                numericUpDownExperience.Value = master.ExperienceYears;

                if (master.BirthDate.HasValue)
                {
                    var localDate = master.BirthDate.Value.ToLocalTime().Date;
                    dateTimePickerBirthDate.Value = localDate;
                    dateTimePickerBirthDate.Checked = true;
                }
                else
                {
                    dateTimePickerBirthDate.Checked = false;
                }
            }
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            var lastName = textBoxLastName.Text.Trim();
            var firstName = textBoxFirstName.Text.Trim();
            var middleName = textBoxMiddleName.Text.Trim();
            var phone = maskedTextBoxPhone.Text.Trim();
            var experience = (int)numericUpDownExperience.Value;

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Введите фамилию", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Введите имя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime? birthDate = null;
                if (dateTimePickerBirthDate.Checked && dateTimePickerBirthDate.Value != dateTimePickerBirthDate.MinDate)
                {
                    birthDate = dateTimePickerBirthDate.Value.Date.Kind == DateTimeKind.Utc 
                        ? dateTimePickerBirthDate.Value.Date 
                        : dateTimePickerBirthDate.Value.Date.ToUniversalTime();
                }

                if (MasterId.HasValue)
                {
                    // Редактирование
                    var master = await _dbContext.Masters.FindAsync(MasterId.Value);
                    if (master != null)
                    {
                        master.LastName = lastName;
                        master.FirstName = firstName;
                        master.MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName;
                        master.Phone = string.IsNullOrWhiteSpace(phone) ? null : phone;
                        master.BirthDate = birthDate;
                        master.ExperienceYears = experience;

                        _dbContext.Entry(master).State = EntityState.Modified;
                        await _dbContext.SaveChangesAsync();
                        MessageBox.Show("Мастер обновлен", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Создание
                    var master = new Master
                    {
                        LastName = lastName,
                        FirstName = firstName,
                        MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName,
                        Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                        BirthDate = birthDate,
                        ExperienceYears = experience
                    };

                    _dbContext.Masters.Add(master);
                    await _dbContext.SaveChangesAsync();
                    
                    MessageBox.Show("Мастер создан", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
