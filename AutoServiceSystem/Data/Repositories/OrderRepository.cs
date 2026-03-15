using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с заявками
/// </summary>
public class OrderRepository
{
    private readonly AutoserviceDbContext _context;

    public OrderRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все заявки
    /// </summary>
    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Car)
            .Include(o => o.Master)
            .Include(o => o.Manager)
            .Include(o => o.OrderServices)
                .ThenInclude(os => os.Service)
            .Include(o => o.OrderParts)
                .ThenInclude(op => op.Part)
            .OrderByDescending(o => o.ServiceDateTime)
            .ToListAsync();
    }

    /// <summary>
    /// Получить заявку по ID
    /// </summary>
    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Car)
            .Include(o => o.Master)
            .Include(o => o.Manager)
            .Include(o => o.OrderServices)
                .ThenInclude(os => os.Service)
            .Include(o => o.OrderParts)
                .ThenInclude(op => op.Part)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    /// <summary>
    /// Получить заявки по статусу
    /// </summary>
    public async Task<List<Order>> GetByStatusAsync(OrderStatus status)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Car)
            .Include(o => o.Master)
            .Include(o => o.Manager)
            .Where(o => o.Status == status)
            .OrderByDescending(o => o.ServiceDateTime)
            .ToListAsync();
    }

    /// <summary>
    /// Получить заявки по дате
    /// </summary>
    public async Task<List<Order>> GetByDateRangeAsync(DateTime dateFrom, DateTime dateTo)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Car)
            .Include(o => o.Master)
            .Include(o => o.Manager)
            .Where(o => o.ServiceDateTime >= dateFrom && o.ServiceDateTime <= dateTo)
            .OrderBy(o => o.ServiceDateTime)
            .ToListAsync();
    }

    /// <summary>
    /// Получить заявки по мастеру и дате
    /// </summary>
    public async Task<List<Order>> GetByMasterAndDateAsync(int masterId, DateTime date)
    {
        var dateEnd = date.AddDays(1);
        
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Car)
            .Where(o => o.MasterId == masterId && 
                       o.ServiceDateTime >= date && 
                       o.ServiceDateTime < dateEnd &&
                       o.Status != OrderStatus.Cancelled)
            .OrderBy(o => o.ServiceDateTime)
            .ToListAsync();
    }

    /// <summary>
    /// Создать заявку
    /// </summary>
    public async Task<Order> CreateAsync(Order order)
    {
        order.CreatedAt = DateTime.UtcNow;
        order.UpdatedAt = DateTime.UtcNow;
        
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        
        return order;
    }

    /// <summary>
    /// Обновить заявку
    /// </summary>
    public async Task UpdateAsync(Order order)
    {
        order.UpdatedAt = DateTime.UtcNow;
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить заявку
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Обновить статус заявки
    /// </summary>
    public async Task UpdateStatusAsync(int orderId, OrderStatus status)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Поиск заявок
    /// </summary>
    public async Task<List<Order>> SearchAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllAsync();

        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Car)
            .Include(o => o.Master)
            .Include(o => o.Manager)
            .Where(o => o.OrderNumber.Contains(searchTerm) ||
                       o.Client.LastName.Contains(searchTerm) ||
                       o.Car.Brand.Contains(searchTerm) ||
                       o.Car.Model.Contains(searchTerm) ||
                       (o.Master != null && o.Master.LastName.Contains(searchTerm)))
            .OrderByDescending(o => o.ServiceDateTime)
            .ToListAsync();
    }

    /// <summary>
    /// Проверить, просрочена ли заявка
    /// </summary>
    public async Task UpdateOverdueOrdersAsync()
    {
        var now = DateTime.Now;
        
        var overdueOrders = await _context.Orders
            .Where(o => o.Status == OrderStatus.Pending && 
                       o.ServiceDateTime < now)
            .ToListAsync();

        foreach (var order in overdueOrders)
        {
            order.Status = OrderStatus.Overdue;
            order.UpdatedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }
}
