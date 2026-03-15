using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с автомобилями
/// </summary>
public class CarRepository
{
    private readonly AutoserviceDbContext _context;

    public CarRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все автомобили
    /// </summary>
    public async Task<List<Car>> GetAllAsync()
    {
        return await _context.Cars
            .AsNoTracking()
            .Include(c => c.Owner)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    /// <summary>
    /// Получить автомобиль по ID
    /// </summary>
    public async Task<Car?> GetByIdAsync(int id)
    {
        return await _context.Cars
            .AsNoTracking()
            .Include(c => c.Owner)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <summary>
    /// Создать автомобиль
    /// </summary>
    public async Task<Car> CreateAsync(Car car)
    {
        car.CreatedAt = DateTime.UtcNow;
        
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        
        return car;
    }

    /// <summary>
    /// Обновить автомобиль
    /// </summary>
    public async Task UpdateAsync(Car car)
    {
        var existing = await _context.Cars.FindAsync(car.Id);
        if (existing != null)
        {
            existing.Brand = car.Brand;
            existing.Model = car.Model;
            existing.StateMark = car.StateMark;
            existing.ProductionYear = car.ProductionYear;
            existing.Color = car.Color;
            existing.VinNumber = car.VinNumber;
            existing.OwnerId = car.OwnerId;

            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Удалить автомобиль
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Поиск автомобилей по строке
    /// </summary>
    public async Task<List<Car>> SearchAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllAsync();

        return await _context.Cars
            .Include(c => c.Owner)
            .Where(c => c.Brand.Contains(searchTerm) || 
                       c.Model.Contains(searchTerm) ||
                       (c.StateMark != null && c.StateMark.Contains(searchTerm)) ||
                       (c.VinNumber != null && c.VinNumber.Contains(searchTerm)))
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    /// <summary>
    /// Получить все автомобили для выбора
    /// </summary>
    public async Task<List<Car>> GetAllForSelectionAsync()
    {
        return await _context.Cars
            .OrderBy(c => c.Brand)
            .ThenBy(c => c.Model)
            .ToListAsync();
    }
}
