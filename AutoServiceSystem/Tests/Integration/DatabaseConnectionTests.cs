using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Settings;
using Xunit;

namespace Tests.Integration;

/// <summary>
/// Интеграционные тесты для проверки подключения к базе данных
/// </summary>
public class DatabaseConnectionTests
{
    [Fact]
    public async Task DatabaseConnection_TestConnection_Success()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AutoserviceDbContext>()
            .UseNpgsql(DBConfig.ConnectionString)
            .Options;

        using var dbContext = new AutoserviceDbContext(options);

        // Act & Assert
        await dbContext.Database.OpenConnectionAsync();
        Assert.True(dbContext.Database.CanConnect());
    }

    [Fact]
    public async Task UserRepository_Authenticate_AdminUser()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AutoserviceDbContext>()
            .UseNpgsql(DBConfig.ConnectionString)
            .Options;

        using var dbContext = new AutoserviceDbContext(options);
        var userRepository = new UserRepository(dbContext);

        // Act
        var result = await userRepository.AuthenticateAsync("admin", "admin");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("admin", result.Username);
        Assert.Equal(UserRole.Admin, result.Role);
    }
}
