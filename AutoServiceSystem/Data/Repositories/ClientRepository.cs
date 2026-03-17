using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с клиентами
/// </summary>
public class ClientRepository
{
    private readonly AutoserviceDbContext _context;

    public ClientRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить всех клиентов
    /// </summary>
    public async Task<List<Client>> GetAllAsync()
    {
        return await _context.Clients
            .AsNoTracking()
            .Where(c => c.IsActive)
            .OrderBy(c => c.LastName)
            .ToListAsync();
    }

    /// <summary>
    /// Получить клиента по ID
    /// </summary>
    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    /// <summary>
    /// Создать клиента
    /// </summary>
    public async Task<Client> CreateAsync(Client client)
    {
        client.CreatedAt = DateTime.UtcNow;
        client.IsActive = true;
        
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        
        return client;
    }

    /// <summary>
    /// Обновить клиента
    /// </summary>
    public async Task UpdateAsync(Client client)
    {
        var existing = await _context.Clients.FindAsync(client.Id);
        if (existing != null)
        {
            existing.Type = client.Type;
            existing.LastName = client.LastName;
            existing.FirstName = client.FirstName;
            existing.MiddleName = client.MiddleName;
            existing.Phone = client.Phone;
            existing.Email = client.Email;
            existing.Address = client.Address;
            existing.Inn = client.Inn;
            // Не обновляем CreatedAt и IsActive
            
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Удалить клиента (деактивировать)
    /// </summary>
    public async Task DeleteAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            client.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Поиск клиентов по строке
    /// </summary>
    public async Task<List<Client>> SearchAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllAsync();

        return await _context.Clients
            .Where(c => c.IsActive &&
                (c.LastName.Contains(searchTerm) ||
                 c.FirstName.Contains(searchTerm) ||
                 (c.MiddleName != null && c.MiddleName.Contains(searchTerm)) ||
                 c.Phone.Contains(searchTerm) ||
                 (c.Email != null && c.Email.Contains(searchTerm)) ||
                 (c.Address != null && c.Address.Contains(searchTerm)) ||
                 (c.Inn != null && c.Inn.Contains(searchTerm))))
            .OrderBy(c => c.LastName)
            .ToListAsync();
    }

    /// <summary>
    /// Фильтрация клиентов по поиску и типу
    /// </summary>
    public async Task<List<Client>> FilterAsync(
        string? searchTerm = null,
        ClientType? type = null)
    {
        var query = _context.Clients
            .Where(c => c.IsActive)
            .AsQueryable();

        // Поиск по текстовому полю
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(c =>
                c.LastName.Contains(searchTerm) ||
                c.FirstName.Contains(searchTerm) ||
                (c.MiddleName != null && c.MiddleName.Contains(searchTerm)) ||
                c.Phone.Contains(searchTerm) ||
                (c.Email != null && c.Email.Contains(searchTerm)) ||
                (c.Address != null && c.Address.Contains(searchTerm)) ||
                (c.Inn != null && c.Inn.Contains(searchTerm)));
        }

        // Фильтр по типу клиента
        if (type.HasValue)
        {
            query = query.Where(c => c.Type == type.Value);
        }

        return await query.OrderBy(c => c.LastName).ToListAsync();
    }
}
