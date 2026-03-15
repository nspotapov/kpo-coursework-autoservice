using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public class UserRepository
{
    private readonly AutoserviceDbContext _context;

    public UserRepository(AutoserviceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить пользователя по логину
    /// </summary>
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
    }

    /// <summary>
    /// Проверка пароля пользователя
    /// </summary>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    /// <summary>
    /// Аутентификация пользователя
    /// </summary>
    public async Task<User?> AuthenticateAsync(string username, string password)
    {
        var user = await GetUserByUsernameAsync(username);
        
        if (user == null)
            return null;

        if (!VerifyPassword(password, user.Password))
            return null;

        return user;
    }

    /// <summary>
    /// Получить всех менеджеров
    /// </summary>
    public async Task<List<User>> GetManagersAsync()
    {
        return await _context.Users
            .Where(u => u.Role == UserRole.Manager && u.IsActive)
            .OrderBy(u => u.LastName)
            .ToListAsync();
    }

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    public async Task<User> CreateUserAsync(User user, string password)
    {
        var existingUser = await GetUserByUsernameAsync(user.Username);
        if (existingUser != null)
            throw new InvalidOperationException("Пользователь с таким логином уже существует");

        user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        user.CreatedAt = DateTime.UtcNow;
        user.IsActive = true;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    /// <summary>
    /// Обновить пользователя
    /// </summary>
    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Обновить пароль пользователя
    /// </summary>
    public async Task UpdatePasswordAsync(int userId, string newPassword)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Удалить пользователя (деактивировать)
    /// </summary>
    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            user.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Where(u => u.IsActive)
            .OrderBy(u => u.LastName)
            .ToListAsync();
    }
}
