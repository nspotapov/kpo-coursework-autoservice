using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public partial class FormReports : Form
    {
        private readonly AutoserviceDbContext _dbContext;
        private readonly CheckRepository _checkRepository;

        public FormReports()
        {
            InitializeComponent();
            InitializeForm();

            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceDbContext>()
                .UseNpgsql(Settings.DBConfig.ConnectionString)
                .Options;

            _dbContext = new AutoserviceDbContext(optionsBuilder);
            _checkRepository = new CheckRepository(_dbContext);
        }

        private void InitializeForm()
        {
            // Устанавливаем даты по умолчанию (текущий месяц)
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);
            var endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            dateTimePickerFrom.Value = startOfMonth;
            dateTimePickerTo.Value = endOfMonth;
        }

        private async void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            await GenerateReportAsync();
        }

        private async Task GenerateReportAsync()
        {
            try
            {
                var dateFrom = DateTime.SpecifyKind(dateTimePickerFrom.Value.Date, DateTimeKind.Utc);
                var dateTo = DateTime.SpecifyKind(dateTimePickerTo.Value.Date.AddDays(1), DateTimeKind.Utc);

                // Получаем все чеки за период
                var checks = await _dbContext.Checks
                    .AsNoTracking()
                    .Include(c => c.Order)
                        .ThenInclude(o => o.Client)
                    .Include(c => c.Order)
                        .ThenInclude(o => o.Car)
                    .Include(c => c.Order)
                        .ThenInclude(o => o.Manager)
                    .Include(c => c.Order)
                        .ThenInclude(o => o.OrderServices)
                            .ThenInclude(os => os.Service)
                    .Include(c => c.Order)
                        .ThenInclude(o => o.OrderParts)
                            .ThenInclude(op => op.Part)
                    .Where(c => c.CreatedAt >= dateFrom && c.CreatedAt < dateTo)
                    .OrderBy(c => c.CreatedAt)
                    .ToListAsync();

                // Генерируем HTML
                var html = GenerateHtmlReport(checks, dateFrom, dateTo);

                // Показываем в веб-браузере
                webBrowserReport.DocumentText = html;

                labelStatus.Text = $"Сформировано {checks.Count} чеков за период";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка формирования отчёта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateHtmlReport(List<Check> checks, DateTime dateFrom, DateTime dateTo)
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang='ru'>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset='UTF-8'>");
            sb.AppendLine("<title>Отчёт по выполненным заказам</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; }");
            sb.AppendLine("h1 { color: #333; }");
            sb.AppendLine(".header { background: #f0f0f0; padding: 15px; margin-bottom: 20px; border-radius: 5px; }");
            sb.AppendLine(".period { color: #666; }");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            sb.AppendLine("th, td { border: 1px solid #ddd; padding: 10px; text-align: left; }");
            sb.AppendLine("th { background: #4CAF50; color: white; }");
            sb.AppendLine("tr:nth-child(even) { background: #f9f9f9; }");
            sb.AppendLine("tr:hover { background: #f0f0f0; }");
            sb.AppendLine(".order-number { font-weight: bold; color: #2196F3; }");
            sb.AppendLine(".services, .parts { font-size: 0.9em; color: #555; }");
            sb.AppendLine(".total { font-weight: bold; color: #4CAF50; }");
            sb.AppendLine(".no-data { text-align: center; color: #999; padding: 30px; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");

            // Шапка отчёта
            sb.AppendLine("<h1>📊 Отчёт по выполненным заказам</h1>");
            sb.AppendLine("<div class='header'>");
            sb.AppendLine($"<strong>Период:</strong> <span class='period'>{dateFrom:dd.MM.yyyy} - {dateTo.AddDays(-1):dd.MM.yyyy}</span><br>");
            sb.AppendLine($"<strong>Дата формирования:</strong> {DateTime.Now:dd.MM.yyyy HH:mm}<br>");
            sb.AppendLine($"<strong>Всего чеков:</strong> {checks.Count}");
            sb.AppendLine("</div>");

            if (checks.Count == 0)
            {
                sb.AppendLine("<div class='no-data'>Нет данных за выбранный период</div>");
            }
            else
            {
                sb.AppendLine("<table>");
                sb.AppendLine("<thead>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th>№</th>");
                sb.AppendLine("<th>Заявка</th>");
                sb.AppendLine("<th>Клиент</th>");
                sb.AppendLine("<th>Автомобиль</th>");
                sb.AppendLine("<th>Менеджер</th>");
                sb.AppendLine("<th>Дата исполнения</th>");
                sb.AppendLine("<th>Услуги</th>");
                sb.AppendLine("<th>Запчасти</th>");
                sb.AppendLine("<th>Итого</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");

                decimal grandTotal = 0;

                foreach (var check in checks)
                {
                    var order = check.Order;
                    var servicesList = order.OrderServices
                        .Select(os => $"{os.Service.Name} ({os.Quantity} шт. × {os.Price:F2} ₽)")
                        .ToList();

                    var partsList = order.OrderParts
                        .Select(op => $"{op.Part.Name} ({op.Quantity} шт. × {op.Price:F2} ₽)")
                        .ToList();

                    var total = order.TotalPrice ?? 0;
                    grandTotal += total;

                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>{checks.IndexOf(check) + 1}</td>");
                    sb.AppendLine($"<td class='order-number'>{order.OrderNumber}</td>");
                    sb.AppendLine($"<td>{order.Client.FullName}</td>");
                    sb.AppendLine($"<td>{order.Car.Brand} {order.Car.Model} {order.Car.StateMark}</td>");
                    sb.AppendLine($"<td>{order.Manager.FullName}</td>");
                    sb.AppendLine($"<td>{order.ServiceDateTime:dd.MM.yyyy HH:mm}</td>");
                    sb.AppendLine($"<td class='services'>{string.Join("<br>", servicesList)}</td>");
                    sb.AppendLine($"<td class='parts'>{string.Join("<br>", partsList)}</td>");
                    sb.AppendLine($"<td class='total'>{total:F2} ₽</td>");
                    sb.AppendLine("</tr>");
                }

                // Итоговая строка
                sb.AppendLine("<tr style='background: #e8f5e9; font-weight: bold;'>");
                sb.AppendLine("<td colspan='8' style='text-align: right;'>Общая сумма:</td>");
                sb.AppendLine($"<td class='total'>{grandTotal:F2} ₽</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
            }

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(webBrowserReport.Document?.Body?.InnerText))
                {
                    MessageBox.Show("Сначала сформируйте отчёт", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "HTML файлы|*.html|Все файлы|*.*";
                saveFileDialog.FileName = $"Otchet_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                saveFileDialog.Title = "Сохранить отчёт";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var htmlContent = webBrowserReport.DocumentText;
                    File.WriteAllText(saveFileDialog.FileName, htmlContent, System.Text.Encoding.UTF8);
                    MessageBox.Show($"Отчёт сохранён в файл:\n{saveFileDialog.FileName}", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
