using Data.Repositories;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace View
{
    /// <summary>
    /// Форма выбора заявки для создания чека
    /// </summary>
    public partial class FormOrderSelector : Form
    {
        public int? SelectedOrderId { get; private set; }

        private readonly OrderRepository _orderRepository;

        public FormOrderSelector(OrderRepository orderRepository)
        {
            InitializeComponent();
            _orderRepository = orderRepository;

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewOrders.Columns.Clear();
            dataGridViewOrders.Columns.Add("Id", "Id");
            dataGridViewOrders.Columns.Add("OrderNumber", "№ заявки");
            dataGridViewOrders.Columns.Add("Client", "Клиент");
            dataGridViewOrders.Columns.Add("Car", "Автомобиль");
            dataGridViewOrders.Columns.Add("Master", "Мастер");
            dataGridViewOrders.Columns.Add("Status", "Статус");
            dataGridViewOrders.Columns.Add("DateTime", "Дата/время");

            dataGridViewOrders.Columns["Id"].Visible = false;
            dataGridViewOrders.Columns["OrderNumber"].Width = 100;
            dataGridViewOrders.Columns["Client"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewOrders.Columns["Car"].Width = 150;
            dataGridViewOrders.Columns["Master"].Width = 120;
            dataGridViewOrders.Columns["Status"].Width = 100;
            dataGridViewOrders.Columns["DateTime"].Width = 120;
        }

        private async void FormOrderSelector_Load(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private async Task LoadOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            dataGridViewOrders.Rows.Clear();
            foreach (var order in orders)
            {
                var statusName = order.Status switch
                {
                    OrderStatus.Pending => "Ожидает",
                    OrderStatus.InProgress => "В работе",
                    OrderStatus.Completed => "Выполнена",
                    OrderStatus.Overdue => "Просрочена",
                    OrderStatus.Cancelled => "Отменена",
                    _ => order.Status.ToString()
                };

                dataGridViewOrders.Rows.Add(
                    order.Id,
                    order.OrderNumber,
                    order.Client.FullName,
                    $"{order.Car.Brand} {order.Car.Model}",
                    order.Master?.FullName ?? "-",
                    statusName,
                    order.ServiceDateTime.ToString("dd.MM.yyyy HH:mm")
                );
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                SelectedOrderId = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells["Id"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите заявку", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dataGridViewOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                buttonOK_Click(sender, e);
            }
        }
    }
}
