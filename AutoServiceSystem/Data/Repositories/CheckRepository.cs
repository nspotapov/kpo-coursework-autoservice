using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с чеками
/// </summary>
public class CheckRepository
{
    private readonly AutoserviceDbContext _context;

    public CheckRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все чеки
    /// </summary>
    public async Task<List<Check>> GetAllAsync()
    {
        return await _context.Checks
            .Include(c => c.Order)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    /// <summary>
    /// Получить чек по ID
    /// </summary>
    public async Task<Check?> GetByIdAsync(int id)
    {
        return await _context.Checks
            .Include(c => c.Order)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <summary>
    /// Получить чек по заявке
    /// </summary>
    public async Task<Check?> GetByOrderIdAsync(int orderId)
    {
        return await _context.Checks
            .Include(c => c.Order)
            .FirstOrDefaultAsync(c => c.OrderId == orderId);
    }

    /// <summary>
    /// Создать чек
    /// </summary>
    public async Task<Check> CreateAsync(Check check)
    {
        check.CreatedAt = DateTime.UtcNow;
        
        _context.Checks.Add(check);
        await _context.SaveChangesAsync();
        
        return check;
    }

    /// <summary>
    /// Удалить чек
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var check = await _context.Checks.FindAsync(id);
        if (check != null)
        {
            _context.Checks.Remove(check);
            await _context.SaveChangesAsync();
        }
    }
}
