using Data;
using Data.Models;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormMasterSchedule : Form
    {
        private readonly List<Master> _masters;
        private readonly DateTime _selectedDate;
        private readonly AutoserviceDbContext _dbContext;
        private readonly MasterAvailabilityService _availabilityService;

        public DateTime? SelectedDateTime { get; private set; }
        public Master? SelectedMaster { get; private set; }

        public FormMasterSchedule(List<Master> masters, DateTime selectedDate)
        {
            InitializeComponent();

            _masters = masters;
            _selectedDate = selectedDate.Date;

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _availabilityService = new MasterAvailabilityService(_dbContext);

            labelSelectedDate.Text = $"Расписание на {_selectedDate:dd.MM.yyyy}";
            
            InitializeDataGridView();
            LoadMasterSchedule();
        }

        private void FormMasterSchedule_Load(object sender, EventArgs e)
        {
            // Форма уже загружена в конструкторе
        }

        private void InitializeDataGridView()
        {
            dataGridViewSchedule.Columns.Clear();
            dataGridViewSchedule.Columns.Add("Time", "Время");
            
            foreach (var master in _masters)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    Name = $"Master_{master.Id}",
                    HeaderText = master.FullName,
                    Width = 120,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dataGridViewSchedule.Columns.Add(column);
            }
        }

        private async void LoadMasterSchedule()
        {
            dataGridViewSchedule.Rows.Clear();

            // Генерируем временные слоты с 8:00 до 20:00 с шагом 30 минут
            var currentTime = _selectedDate.Date + AppConstants.WorkDayStart;
            var endTime = _selectedDate.Date + AppConstants.WorkDayEnd;

            while (currentTime < endTime)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridViewSchedule);
                row.Cells[0].Value = currentTime.ToString("HH:mm");

                // Для каждого мастера проверяем доступность
                for (int i = 0; i < _masters.Count; i++)
                {
                    var master = _masters[i];
                    var isAvailable = await _availabilityService.IsMasterAvailableAtAsync(
                        master.Id, currentTime, 30); // Проверяем слот 30 минут

                    var cell = row.Cells[i + 1];

                    if (currentTime.TimeOfDay >= AppConstants.BreakStart && 
                        currentTime.TimeOfDay < AppConstants.BreakEnd)
                    {
                        // Перерыв
                        cell.Value = "Обед";
                        cell.Style.BackColor = Color.Orange;
                        cell.Style.ForeColor = Color.Black;
                    }
                    else if (isAvailable)
                    {
                        // Свободен
                        cell.Value = "✓";
                        cell.Style.BackColor = Color.LightGreen;
                        cell.Style.ForeColor = Color.DarkGreen;
                        cell.Style.Font = new Font(dataGridViewSchedule.Font, FontStyle.Bold);
                    }
                    else
                    {
                        // Занят
                        cell.Value = "✗";
                        cell.Style.BackColor = Color.LightCoral;
                        cell.Style.ForeColor = Color.DarkRed;
                    }
                }

                dataGridViewSchedule.Rows.Add(row);
                currentTime = currentTime.AddMinutes(30);
            }
        }

        private void dataGridViewSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
                return;

            var cell = dataGridViewSchedule.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
            // Проверяем, что слот свободен (зелёный)
            if (cell.Style.BackColor == Color.LightGreen)
            {
                var masterId = _masters[e.ColumnIndex - 1].Id;
                var timeString = dataGridViewSchedule.Rows[e.RowIndex].Cells[0].Value?.ToString();
                
                if (TimeSpan.TryParseExact(timeString?.Replace(":", "") + "00", "hhmmss", null, out var timeSpan))
                {
                    SelectedMaster = _masters.FirstOrDefault(m => m.Id == masterId);
                    SelectedDateTime = _selectedDate.Date + timeSpan;
                    
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else if (cell.Style.BackColor == Color.LightCoral)
            {
                MessageBox.Show("Это время занято. Выберите свободный слот (зелёный).", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (SelectedMaster != null && SelectedDateTime.HasValue)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите свободный слот (зелёная ячейка с галочкой).", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewSchedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
            {
                dataGridViewSchedule_CellClick(sender, e);
            }
        }
    }
}
