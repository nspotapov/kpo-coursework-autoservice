using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с запчастями
/// </summary>
public class PartRepository
{
    private readonly AutoserviceDbContext _context;

    public PartRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все активные запчасти
    /// </summary>
    public async Task<List<Part>> GetAllAsync()
    {
        return await _context.Parts
            .Where(p => p.IsActive)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    /// <summary>
    /// Получить запчасть по ID
    /// </summary>
    public async Task<Part?> GetByIdAsync(int id)
    {
        return await _context.Parts.FindAsync(id);
    }

    /// <summary>
    /// Создать запчасть
    /// </summary>
    public async Task<Part> CreateAsync(Part part)
    {
        part.IsActive = true;
        
        _context.Parts.Add(part);
        await _context.SaveChangesAsync();
        
        return part;
    }

    /// <summary>
    /// Обновить запчасть
    /// </summary>
    public async Task UpdateAsync(Part part)
    {
        _context.Parts.Update(part);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить запчасть (деактивировать)
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var part = await _context.Parts.FindAsync(id);
        if (part != null)
        {
            part.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Поиск запчастей по строке
    /// </summary>
    public async Task<List<Part>> SearchAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllAsync();

        return await _context.Parts
            .Where(p => p.IsActive && 
                (p.Name.Contains(searchTerm) || 
                 (p.Article != null && p.Article.Contains(searchTerm))))
            .OrderBy(p => p.Name)
            .ToListAsync();
    }
}
