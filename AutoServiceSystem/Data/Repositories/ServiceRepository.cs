using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с услугами
/// </summary>
public class ServiceRepository
{
    private readonly AutoserviceDbContext _context;

    public ServiceRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все активные услуги
    /// </summary>
    public async Task<List<Service>> GetAllAsync()
    {
        return await _context.Services
            .Where(s => s.IsActive)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    /// <summary>
    /// Получить услугу по ID
    /// </summary>
    public async Task<Service?> GetByIdAsync(int id)
    {
        return await _context.Services.FindAsync(id);
    }

    /// <summary>
    /// Создать услугу
    /// </summary>
    public async Task<Service> CreateAsync(Service service)
    {
        service.IsActive = true;
        
        _context.Services.Add(service);
        await _context.SaveChangesAsync();
        
        return service;
    }

    /// <summary>
    /// Обновить услугу
    /// </summary>
    public async Task UpdateAsync(Service service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить услугу (деактивировать)
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service != null)
        {
            service.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}
