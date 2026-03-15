using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormChecksList : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly CheckRepository _checkRepository;
        private readonly OrderRepository _orderRepository;

        public FormChecksList()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _checkRepository = new CheckRepository(_dbContext);
            _orderRepository = new OrderRepository(_dbContext);

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewChecks.Columns.Clear();
            dataGridViewChecks.Columns.Add("Id", "Id");
            dataGridViewChecks.Columns.Add("CheckNumber", "№ чека");
            dataGridViewChecks.Columns.Add("OrderNumber", "№ заявки");
            dataGridViewChecks.Columns.Add("ClientName", "Клиент");
            dataGridViewChecks.Columns.Add("CarInfo", "Автомобиль");
            dataGridViewChecks.Columns.Add("TotalAmount", "Сумма");
            dataGridViewChecks.Columns.Add("MasterName", "Мастер");
            dataGridViewChecks.Columns.Add("ManagerName", "Менеджер");
            dataGridViewChecks.Columns.Add("CreatedAt", "Дата создания");

            dataGridViewChecks.Columns["Id"].Visible = false;
            dataGridViewChecks.Columns["CheckNumber"].Width = 100;
            dataGridViewChecks.Columns["OrderNumber"].Width = 100;
            dataGridViewChecks.Columns["ClientName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewChecks.Columns["CarInfo"].Width = 150;
            dataGridViewChecks.Columns["TotalAmount"].Width = 100;
            dataGridViewChecks.Columns["MasterName"].Width = 120;
            dataGridViewChecks.Columns["ManagerName"].Width = 120;
            dataGridViewChecks.Columns["CreatedAt"].Width = 120;
        }

        private async void FormChecksList_Load(object sender, EventArgs e)
        {
            await LoadChecksAsync();
        }

        private async Task LoadChecksAsync()
        {
            var checks = await _checkRepository.GetAllAsync();

            dataGridViewChecks.Rows.Clear();
            foreach (var check in checks)
            {
                dataGridViewChecks.Rows.Add(
                    check.Id,
                    check.CheckNumber,
                    check.Order.OrderNumber,
                    check.ClientName,
                    check.CarInfo,
                    $"{check.TotalAmount:C0}",
                    check.MasterName,
                    check.ManagerName,
                    check.CreatedAt.ToString("dd.MM.yyyy HH:mm")
                );
            }

            labelTotal.Text = $"Всего чеков: {checks.Count}";
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            // Сначала нужно выбрать выполненную заявку без чека
            var dialog = new FormOrderSelector(_orderRepository);
            if (dialog.ShowDialog() == DialogResult.OK && dialog.SelectedOrderId.HasValue)
            {
                await CreateCheckForOrderAsync(dialog.SelectedOrderId.Value);
            }
        }

        private async Task CreateCheckForOrderAsync(int orderId)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(orderId);
                if (order == null)
                {
                    MessageBox.Show("Заявка не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (order.Status != OrderStatus.Completed)
                {
                    var result = MessageBox.Show(
                        $"Заявка имеет статус \"{GetStatusName(order.Status)}\". Создать чек?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;
                }

                var existingCheck = await _checkRepository.GetByOrderIdAsync(orderId);
                if (existingCheck != null)
                {
                    MessageBox.Show("Чек для этой заявки уже существует", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создаём чек
                var servicesTotal = order.OrderServices.Sum(s => s.Price * s.Quantity);
                var partsTotal = order.OrderParts.Sum(p => p.Price * p.Quantity);
                var totalAmount = servicesTotal + partsTotal;

                var date = DateTime.Now;
                var checkNumber = $"CHK-{date:yyyyMMdd}-{orderId:D3}";

                var check = new Check
                {
                    OrderId = orderId,
                    CheckNumber = checkNumber,
                    ClientName = order.Client.FullName,
                    CarInfo = $"{order.Car.Brand} {order.Car.Model} {order.Car.StateMark}",
                    ServicesTotal = servicesTotal,
                    PartsTotal = partsTotal,
                    TotalAmount = totalAmount,
                    MasterName = order.Master?.FullName,
                    ManagerName = order.Manager.FullName
                };

                await _checkRepository.CreateAsync(check);

                MessageBox.Show($"Чек {checkNumber} создан", "Успешно",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadChecksAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusName(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => "Ожидает",
                OrderStatus.InProgress => "В работе",
                OrderStatus.Completed => "Выполнена",
                OrderStatus.Overdue => "Просрочена",
                OrderStatus.Cancelled => "Отменена",
                _ => status.ToString()
            };
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewChecks.SelectedRows.Count == 1)
            {
                var checkId = Convert.ToInt32(dataGridViewChecks.SelectedRows[0].Cells["Id"].Value);
                var checkNumber = dataGridViewChecks.SelectedRows[0].Cells["CheckNumber"].Value.ToString();

                var result = MessageBox.Show($"Удалить чек \"{checkNumber}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _checkRepository.DeleteAsync(checkId);
                    await LoadChecksAsync();
                }
            }
            else
            {
                MessageBox.Show("Выберите чек для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
