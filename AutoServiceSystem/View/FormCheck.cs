using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace View
{
    public partial class FormCheck : Form
    {
        private readonly int _orderId;
        private readonly AutoserviceDbContext _dbContext;
        private readonly OrderRepository _orderRepository;
        private readonly CheckRepository _checkRepository;

        private Order? _order;

        public FormCheck(int orderId)
        {
            InitializeComponent();

            _orderId = orderId;

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _orderRepository = new OrderRepository(_dbContext);
            _checkRepository = new CheckRepository(_dbContext);
        }

        private async void FormCheck_Load(object sender, EventArgs e)
        {
            await LoadOrderDataAsync();
        }

        private async Task LoadOrderDataAsync()
        {
            _order = await _orderRepository.GetByIdAsync(_orderId);
            
            if (_order == null)
            {
                MessageBox.Show("Заявка не найдена", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Проверяем, есть ли уже чек
            var existingCheck = await _dbContext.Checks
                .FirstOrDefaultAsync(c => c.OrderId == _orderId);
            
            if (existingCheck != null)
            {
                MessageBox.Show("Чек для этой заявки уже существует", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            // Заполняем данные
            labelOrderNumber.Text = _order.OrderNumber;
            labelClientName.Text = _order.Client.FullName;
            labelCarInfo.Text = $"{_order.Car.Brand} {_order.Car.Model} {_order.Car.StateMark}";
            labelMasterName.Text = _order.Master?.FullName ?? "Не назначен";
            labelManagerName.Text = _order.Manager.FullName;
            labelServiceDateTime.Text = _order.ServiceDateTime.ToString("dd.MM.yyyy HH:mm");

            // Загружаем услуги
            var services = await _dbContext.OrderServices
                .Where(os => os.OrderId == _orderId)
                .Include(os => os.Service)
                .ToListAsync();

            dataGridViewServices.Rows.Clear();
            decimal servicesTotal = 0;
            foreach (var os in services)
            {
                var total = os.Price * os.Quantity;
                servicesTotal += total;
                dataGridViewServices.Rows.Add(
                    os.Service.Name,
                    os.Quantity,
                    $"{os.Price:C0}",
                    $"{total:C0}"
                );
            }

            // Загружаем запчасти
            var parts = await _dbContext.OrderParts
                .Where(op => op.OrderId == _orderId)
                .Include(op => op.Part)
                .ToListAsync();

            dataGridViewParts.Rows.Clear();
            decimal partsTotal = 0;
            foreach (var op in parts)
            {
                var total = op.Price * op.Quantity;
                partsTotal += total;
                dataGridViewParts.Rows.Add(
                    op.Part.Name,
                    op.Quantity,
                    $"{op.Price:C0}",
                    $"{total:C0}"
                );
            }

            // Итоговая сумма
            var grandTotal = servicesTotal + partsTotal;
            labelServicesTotal.Text = $"Услуги: {servicesTotal:C0}";
            labelPartsTotal.Text = $"Запчасти: {partsTotal:C0}";
            labelTotalAmount.Text = $"Итого: {grandTotal:C0}";
        }

        private async void buttonCreateCheck_Click(object sender, EventArgs e)
        {
            if (_order == null)
            {
                MessageBox.Show("Заявка не загружена", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Генерируем номер чека
                var date = DateTime.Now;
                var checkNumber = $"CHK-{date:yyyyMMdd}-{_orderId:D3}";

                // Рассчитываем суммы
                var servicesTotal = _order.OrderServices.Sum(os => os.Price * os.Quantity);
                var partsTotal = _order.OrderParts.Sum(op => op.Price * op.Quantity);
                var totalAmount = servicesTotal + partsTotal;

                // Создаём чек
                var check = new Check
                {
                    OrderId = _orderId,
                    CheckNumber = checkNumber,
                    ClientName = _order.Client.FullName,
                    CarInfo = $"{_order.Car.Brand} {_order.Car.Model} {_order.Car.StateMark}",
                    ServicesTotal = servicesTotal,
                    PartsTotal = partsTotal,
                    TotalAmount = totalAmount,
                    MasterName = _order.Master?.FullName,
                    ManagerName = _order.Manager.FullName,
                    CreatedAt = DateTime.UtcNow
                };

                await _checkRepository.CreateAsync(check);

                // Обновляем статус заявки
                _order.Status = OrderStatus.Completed;
                _order.UpdatedAt = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();

                MessageBox.Show($"Чек {checkNumber} создан\nЗаявка переведена в статус \"Выполнена\"",
                    "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void buttonPrintHtml_Click(object sender, EventArgs e)
        {
            if (_order == null) return;

            try
            {
                var htmlContent = GenerateHtmlCheck();
                var tempFile = Path.Combine(Path.GetTempPath(), $"check_{_orderId}.html");
                await File.WriteAllTextAsync(tempFile, htmlContent, Encoding.UTF8);

                // Открываем в браузере по умолчанию
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true
                });

                MessageBox.Show("Чек открыт в браузере. Вы можете распечатать его (Ctrl+P)",
                    "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации HTML: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateHtmlCheck()
        {
            if (_order == null) return string.Empty;

            var servicesTotal = _order.OrderServices.Sum(os => os.Price * os.Quantity);
            var partsTotal = _order.OrderParts.Sum(op => op.Price * op.Quantity);
            var totalAmount = servicesTotal + partsTotal;

            var sb = new StringBuilder();
            sb.AppendLine(@"<!DOCTYPE html>
<html lang='ru'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Чек № " + $"CHK-{DateTime.Now:yyyyMMdd}-{_orderId:D3}" + @"</title>
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
        <p>Чек выполнения работ № CHK-" + $"{DateTime.Now:yyyyMMdd}-{_orderId:D3}" + @"</p>
        <p>Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + @"</p>
    </div>

    <div class='info'>
        <div class='info-row'>
            <span class='info-label'>Клиент:</span>
            <span>" + _order.Client.FullName + @"</span>
        </div>
        <div class='info-row'>
            <span class='info-label'>Автомобиль:</span>
            <span>" + $"{_order.Car.Brand} {_order.Car.Model} {_order.Car.StateMark}" + @"</span>
        </div>
        <div class='info-row'>
            <span class='info-label'>Мастер:</span>
            <span>" + (_order.Master?.FullName ?? "Не назначен") + @"</span>
        </div>
        <div class='info-row'>
            <span class='info-label'>Менеджер:</span>
            <span>" + _order.Manager.FullName + @"</span>
        </div>
        <div class='info-row'>
            <span class='info-label'>Дата/время услуги:</span>
            <span>" + _order.ServiceDateTime.ToString("dd.MM.yyyy HH:mm") + @"</span>
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

            foreach (var os in _order.OrderServices)
            {
                sb.AppendLine($@"        <tr>
            <td>{os.Service.Name}</td>
            <td>{os.Quantity}</td>
            <td>{os.Price:C0}</td>
            <td>{os.Price * os.Quantity:C0}</td>
        </tr>");
            }

            sb.AppendLine($@"        <tr>
            <td colspan='3' style='text-align: right;'><b>Итого за услуги:</b></td>
            <td>{servicesTotal:C0}</td>
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

            if (_order.OrderParts.Any())
            {
                foreach (var op in _order.OrderParts)
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
            <td>{partsTotal:C0}</td>
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
        <p>Общая сумма: {totalAmount:C0}</p>
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
