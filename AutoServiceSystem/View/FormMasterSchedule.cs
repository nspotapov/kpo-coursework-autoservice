using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormMasterSchedule : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly List<Master> _masters;
        private readonly DateTime _selectedDate;

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

            InitializeDataGridView();
            LoadMasterSchedule();
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
                    Width = 100
                };
                dataGridViewSchedule.Columns.Add(column);
            }
        }

        private async void LoadMasterSchedule()
        {
            labelSelectedDate.Text = $"Расписание на {_selectedDate:dd.MM.yyyy}";

            // Загружаем заявки мастеров на выбранный день
            var startOfDay = _selectedDate.Date;
            var endOfDay = _selectedDate.Date.AddDays(1);

            var orders = await _dbContext.Orders
                .Where(o => o.MasterId.HasValue &&
                           o.ServiceDateTime >= startOfDay &&
                           o.ServiceDateTime < endOfDay &&
                           o.Status != OrderStatus.Cancelled)
                .Include(o => o.Master)
                .Include(o => o.Client)
                .Include(o => o.Car)
                .ToListAsync();

            // Генерируем временные слоты с 9:00 до 18:00
            var timeSlots = new List<TimeSpan>();
            for (int hour = 9; hour < 18; hour++)
            {
                timeSlots.Add(new TimeSpan(hour, 0, 0));
            }

            dataGridViewSchedule.Rows.Clear();

            foreach (var timeSlot in timeSlots)
            {
                var slotDateTime = _selectedDate.Date + timeSlot;
                var row = new DataGridViewRow();
                row.CreateCells(dataGridViewSchedule);
                row.Cells[0].Value = $"{timeSlot.Hours:D2}:00";

                // Проверяем занятость каждого мастера
                for (int i = 0; i < _masters.Count; i++)
                {
                    var master = _masters[i];
                    var isBusy = orders.Any(o => 
                        o.MasterId == master.Id && 
                        o.ServiceDateTime.Hour == timeSlot.Hours);

                    var cell = row.Cells[i + 1];
                    
                    if (isBusy)
                    {
                        cell.Value = "Занят";
                        cell.Style.BackColor = Color.LightCoral;
                        cell.Style.ForeColor = Color.DarkRed;
                        cell.Style.Font = new Font(dataGridViewSchedule.Font, FontStyle.Bold);
                    }
                    else
                    {
                        cell.Value = "Свободен";
                        cell.Style.BackColor = Color.LightGreen;
                        cell.Style.ForeColor = Color.DarkGreen;
                    }
                }

                dataGridViewSchedule.Rows.Add(row);
            }

            // Добавляем информацию о занятых слотах с деталями
            var busyDetails = orders.GroupBy(o => o.MasterId)
                .SelectMany(g => g.Select(o => new
                {
                    MasterId = o.MasterId,
                    Time = o.ServiceDateTime,
                    Info = $"{o.Client.FullName}: {o.Car.Brand} {o.Car.Model}"
                }));

            var detailsText = string.Join("\n", busyDetails.Select(b => 
                $"{_masters.FirstOrDefault(m => m.Id == b.MasterId)?.FullName} - {b.Time:HH:mm} - {b.Info}"));

            if (!string.IsNullOrEmpty(detailsText))
            {
                labelBusyDetails.Text = "Занятые слоты:\n" + detailsText;
            }
        }

        private void dataGridViewSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
                return;

            var cell = dataGridViewSchedule.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
            if (cell.Value?.ToString() == "Свободен")
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
            else
            {
                MessageBox.Show("Это время занято. Выберите свободный слот.", "Внимание",
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
                MessageBox.Show("Выберите свободный слот мастера.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
