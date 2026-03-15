using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с мастерами
/// </summary>
public class MasterRepository
{
    private readonly AutoserviceDbContext _context;

    public MasterRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить всех активных мастеров
    /// </summary>
    public async Task<List<Master>> GetAllAsync()
    {
        return await _context.Masters
            .AsNoTracking()
            .Where(m => m.IsActive)
            .OrderBy(m => m.LastName)
            .ThenBy(m => m.FirstName)
            .ToListAsync();
    }

    /// <summary>
    /// Получить мастера по ID
    /// </summary>
    public async Task<Master?> GetByIdAsync(int id)
    {
        return await _context.Masters.FindAsync(id);
    }

    /// <summary>
    /// Создать мастера
    /// </summary>
    public async Task<Master> CreateAsync(Master master)
    {
        master.IsActive = true;
        master.CreatedAt = DateTime.UtcNow;
        
        _context.Masters.Add(master);
        await _context.SaveChangesAsync();
        
        return master;
    }

    /// <summary>
    /// Обновить мастера
    /// </summary>
    public async Task UpdateAsync(Master master)
    {
        _context.Masters.Update(master);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить мастера (деактивировать)
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var master = await _context.Masters.FindAsync(id);
        if (master != null)
        {
            master.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Получить мастеров для выбора (активных)
    /// </summary>
    public async Task<List<Master>> GetForSelectionAsync()
    {
        return await _context.Masters
            .Where(m => m.IsActive)
            .OrderBy(m => m.LastName)
            .ToListAsync();
    }
}
