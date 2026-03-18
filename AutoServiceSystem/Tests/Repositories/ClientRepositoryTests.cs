using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Repositories;

/// <summary>
/// Тесты для ClientRepository
/// </summary>
public class ClientRepositoryTests : IDisposable
{
    private readonly AutoserviceDbContext _dbContext;
    private readonly ClientRepository _clientRepository;

    public ClientRepositoryTests()
    {
        // Инициализация InMemory базы данных для тестов
        var options = new DbContextOptionsBuilder<AutoserviceDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        _dbContext = new AutoserviceDbContext(options);
        _clientRepository = new ClientRepository(_dbContext);
    }

    #region GetAll Tests

    [Fact]
    public async Task GetAll_EmptyDatabase_ReturnsEmptyList()
    {
        // Act
        var result = await _clientRepository.GetAllAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAll_WithClients_ReturnsAllActiveClients()
    {
        // Arrange
        await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Иванов",
            FirstName = "Иван",
            Phone = "+7 (900) 111-11-11"
        });

        await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Legal,
            LastName = "ООО Тест",
            FirstName = "Организация",
            Phone = "+7 (900) 222-22-22"
        });

        // Act
        var result = await _clientRepository.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_ValidId_ReturnsClient()
    {
        // Arrange
        var client = await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Тестов",
            FirstName = "Тест",
            Phone = "+7 (900) 333-33-33"
        });

        // Act
        var result = await _clientRepository.GetByIdAsync(client.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Тестов", result.LastName);
    }

    [Fact]
    public async Task GetById_InvalidId_ReturnsNull()
    {
        // Act
        var result = await _clientRepository.GetByIdAsync(999);

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region Create Tests

    [Fact]
    public async Task Create_ValidClient_AddsClient()
    {
        // Arrange
        var client = new Client
        {
            Type = ClientType.Individual,
            LastName = "Новиков",
            FirstName = "Новик",
            MiddleName = "Новикович",
            Phone = "+7 (900) 444-44-44",
            Email = "test@test.ru"
        };

        // Act
        var result = await _clientRepository.CreateAsync(client);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Id > 0);
        Assert.Equal("Новиков", result.LastName);
        Assert.True(result.IsActive);
    }

    [Fact]
    public async Task Create_Client_SetsCreatedAt()
    {
        // Arrange
        var client = new Client
        {
            Type = ClientType.Individual,
            LastName = "Созданов",
            FirstName = "Создан",
            Phone = "+7 (900) 555-55-55"
        };

        var beforeCreate = DateTime.UtcNow;

        // Act
        var result = await _clientRepository.CreateAsync(client);

        // Assert
        Assert.InRange(result.CreatedAt, beforeCreate.AddSeconds(-5), DateTime.UtcNow.AddSeconds(5));
    }

    #endregion

    #region Update Tests

    [Fact]
    public async Task Update_ValidClient_UpdatesClient()
    {
        // Arrange
        var client = await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Старый",
            FirstName = "Старый",
            Phone = "+7 (900) 666-66-66"
        });

        client.LastName = "Новый";
        client.Phone = "+7 (900) 777-77-77";

        // Act
        await _clientRepository.UpdateAsync(client);

        // Assert
        var updated = await _clientRepository.GetByIdAsync(client.Id);
        Assert.NotNull(updated);
        Assert.Equal("Новый", updated.LastName);
        Assert.Equal("+7 (900) 777-77-77", updated.Phone);
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_ValidId_DeactivatesClient()
    {
        // Arrange
        var client = await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Удаляев",
            FirstName = "Удалей",
            Phone = "+7 (900) 888-88-88"
        });

        // Act
        await _clientRepository.DeleteAsync(client.Id);

        // Assert
        var result = await _clientRepository.GetByIdAsync(client.Id);
        Assert.NotNull(result);
        Assert.False(result.IsActive);
    }

    [Fact]
    public async Task Delete_InvalidId_DoesNothing()
    {
        // Act & Assert (не должно выбрасывать исключений)
        await _clientRepository.DeleteAsync(999);
    }

    #endregion

    #region Search Tests

    [Fact]
    public async Task Search_EmptyTerm_ReturnsAllClients()
    {
        // Arrange
        await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Первый",
            FirstName = "Первый",
            Phone = "+7 (900) 111-11-11"
        });

        await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Второй",
            FirstName = "Второй",
            Phone = "+7 (900) 222-22-22"
        });

        // Act
        var result = await _clientRepository.SearchAsync("");

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Search_ByLastName_ReturnsMatchingClients()
    {
        // Arrange
        await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Иванов",
            FirstName = "Иван",
            Phone = "+7 (900) 111-11-11"
        });

        await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Петров",
            FirstName = "Петр",
            Phone = "+7 (900) 222-22-22"
        });

        // Act
        var result = await _clientRepository.SearchAsync("Иванов");

        // Assert
        Assert.Single(result);
        Assert.Equal("Иванов", result[0].LastName);
    }

    [Fact]
    public async Task Search_ByPhone_ReturnsMatchingClients()
    {
        // Arrange
        await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Тестов",
            FirstName = "Тест",
            Phone = "+7 (999) 123-45-67"
        });

        // Act
        var result = await _clientRepository.SearchAsync("123-45-67");

        // Assert
        Assert.Single(result);
        Assert.Equal("+7 (999) 123-45-67", result[0].Phone);
    }

    [Fact]
    public async Task Search_OnlyActiveClients_ReturnsActiveOnly()
    {
        // Arrange
        var activeClient = await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Активный",
            FirstName = "Активный",
            Phone = "+7 (900) 111-11-11"
        });

        var inactiveClient = await _clientRepository.CreateAsync(new Client
        {
            Type = ClientType.Individual,
            LastName = "Неактивный",
            FirstName = "Неактивный",
            Phone = "+7 (900) 222-22-22"
        });

        await _clientRepository.DeleteAsync(inactiveClient.Id);

        // Act
        var result = await _clientRepository.SearchAsync("");

        // Assert
        Assert.Single(result);
        Assert.Equal("Активный", result[0].LastName);
    }

    #endregion

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}
