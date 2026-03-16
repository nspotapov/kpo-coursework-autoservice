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
            
            // Добавляем обработчик двойного клика
            dataGridViewChecks.CellDoubleClick += DataGridViewChecks_CellDoubleClick;
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

        /// <summary>
        /// Открытие HTML-чека по двойному клику
        /// </summary>
        private async void DataGridViewChecks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var checkId = Convert.ToInt32(dataGridViewChecks.SelectedRows[0].Cells["Id"].Value);
                await OpenCheckInBrowserAsync(checkId);
            }
        }

        /// <summary>
        /// Открытие чека в браузере
        /// </summary>
        private async Task OpenCheckInBrowserAsync(int checkId)
        {
            try
            {
                var check = await _checkRepository.GetByIdAsync(checkId);
                if (check == null)
                {
                    MessageBox.Show("Чек не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var htmlContent = GenerateHtmlCheck(check);
                var tempFile = Path.Combine(Path.GetTempPath(), $"check_{check.CheckNumber}.html");
                await File.WriteAllTextAsync(tempFile, htmlContent, System.Text.Encoding.UTF8);

                // Открываем в браузере по умолчанию
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии чека: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Генерация HTML-чека
        /// </summary>
        private string GenerateHtmlCheck(Check check)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(@"<!DOCTYPE html>
<html lang='ru'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Чек № " + check.CheckNumber + @"</title>
    <style>
        body { font-family: Arial, sans-serif; max-width: 800px; margin: 0 auto; padding: 20px; }
        .header { text-align: center; border-bottom: 2px solid #333; padding-bottom: 10px; margin-bottom: 20px; }
        .header h1 { margin: 0; color: #333; }
        .info { margin-bottom: 20px; }
        .info-row { display: flex; justify-content: space-between; margin-bottom: 5px; }
        .info-label { font-weight: bold; }
        table { width: 100%; border-collapse: collapse; margin-bottom: 20px; }
        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        th { background-color: #f2f2f2; }
        .total { text-align: right; font-size: 18px; font-weight: bold; }
        .footer { margin-top: 30px; text-align: center; font-size: 12px; color: #666; }
        h2 { border-bottom: 1px solid #ddd; padding-bottom: 5px; }
    </style>
</head>
<body>
    <div class='header'>
        <h1>ИС Автосервис</h1>
        <p>Чек выполнения работ № " + check.CheckNumber + @"</p>
        <p>Дата: " + check.CreatedAt.ToString("dd.MM.yyyy HH:mm") + @"</p>
    </div>

    <div class='info'>
        <div class='info-row'>
            <span class='info-label'>Клиент:</span>
            <span>" + check.ClientName + @"</span>
        </div>
        <div class='info-row'>
            <span class='info-label'>Автомобиль:</span>
            <span>" + check.CarInfo + @"</span>
        </div>
        <div class='info-row'>
            <span class='info-label'>Мастер:</span>
            <span>" + (check.MasterName ?? "Не назначен") + @"</span>
        </div>
        <div class='info-row'>
            <span class='info-label'>Менеджер:</span>
            <span>" + check.ManagerName + @"</span>
        </div>
    </div>

    <h2>Услуги</h2>
    <table>
        <tr>
            <th>Наименование</th>
            <th>Кол-во</th>
            <th>Цена</th>
            <th>Сумма</th>
        </tr>");

            // Получаем услуги из заказа
            var order = _dbContext.Orders
                .Include(o => o.OrderServices)
                .ThenInclude(os => os.Service)
                .Include(o => o.OrderParts)
                .ThenInclude(op => op.Part)
                .FirstOrDefault(o => o.Id == check.OrderId);

            if (order != null)
            {
                foreach (var os in order.OrderServices)
                {
                    sb.AppendLine($@"        <tr>
            <td>{os.Service.Name}</td>
            <td>{os.Quantity}</td>
            <td>{os.Price:C0}</td>
            <td>{os.Price * os.Quantity:C0}</td>
        </tr>");
                }
            }

            sb.AppendLine($@"        <tr>
            <td colspan='3' style='text-align: right;'><b>Итого за услуги:</b></td>
            <td>{check.ServicesTotal:C0}</td>
        </tr>
    </table>

    <h2>Запчасти</h2>
    <table>
        <tr>
            <th>Наименование</th>
            <th>Кол-во</th>
            <th>Цена</th>
            <th>Сумма</th>
        </tr>");

            // Получаем запчасти из заказа
            if (order != null && order.OrderParts.Any())
            {
                foreach (var op in order.OrderParts)
                {
                    sb.AppendLine($@"        <tr>
            <td>{op.Part.Name}</td>
            <td>{op.Quantity}</td>
            <td>{op.Price:C0}</td>
            <td>{op.Price * op.Quantity:C0}</td>
        </tr>");
                }

                sb.AppendLine($@"        <tr>
            <td colspan='3' style='text-align: right;'><b>Итого за запчасти:</b></td>
            <td>{check.PartsTotal:C0}</td>
        </tr>
    </table>");
            }
            else
            {
                sb.AppendLine(@"        <tr>
            <td colspan='4' style='text-align: center;'>Запчасти не использовались</td>
        </tr>
    </table>");
            }

            sb.AppendLine($@"
    <div class='total'>
        <p>Общая сумма: {check.TotalAmount:C0}</p>
    </div>

    <div class='footer'>
        <p>Спасибо за обращение в ИС Автосервис!</p>
        <p>Чек сгенерирован автоматически</p>
    </div>
</body>
</html>");

            return sb.ToString();
        }
    }
}
