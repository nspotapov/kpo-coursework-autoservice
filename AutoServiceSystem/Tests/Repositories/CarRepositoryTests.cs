using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Repositories;

/// <summary>
/// Тесты для CarRepository
/// </summary>
public class CarRepositoryTests : IDisposable
{
    private readonly AutoserviceDbContext _dbContext;
    private readonly CarRepository _carRepository;
    private readonly Client _testClient;

    public CarRepositoryTests()
    {
        // Инициализация InMemory базы данных для тестов
        var options = new DbContextOptionsBuilder<AutoserviceDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_Car_{Guid.NewGuid()}")
            .Options;

        _dbContext = new AutoserviceDbContext(options);
        _carRepository = new CarRepository(_dbContext);

        // Создаём тестового клиента
        _testClient = new Client
        {
            Type = ClientType.Individual,
            LastName = "Владелец",
            FirstName = "Владелец",
            Phone = "+7 (900) 111-11-11"
        };
        _dbContext.Clients.Add(_testClient);
        _dbContext.SaveChanges();
    }

    #region GetAll Tests

    [Fact]
    public async Task GetAll_EmptyDatabase_ReturnsEmptyList()
    {
        // Act
        var result = await _carRepository.GetAllAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAll_WithCars_ReturnsAllCars()
    {
        // Arrange
        await CreateTestCarAsync("Toyota", "Camry");
        await CreateTestCarAsync("Hyundai", "Solaris");

        // Act
        var result = await _carRepository.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_ValidId_ReturnsCar()
    {
        // Arrange
        var car = await CreateTestCarAsync("Kia", "Rio");

        // Act
        var result = await _carRepository.GetByIdAsync(car.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Kia", result.Brand);
    }

    [Fact]
    public async Task GetById_InvalidId_ReturnsNull()
    {
        // Act
        var result = await _carRepository.GetByIdAsync(999);

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region Create Tests

    [Fact]
    public async Task Create_ValidCar_AddsCar()
    {
        // Arrange
        var car = new Car
        {
            Brand = "Volkswagen",
            Model = "Polo",
            StateMark = "А001АА 777",
            ProductionYear = 2020,
            Color = "Чёрный",
            VinNumber = "TEST123456789",
            OwnerId = _testClient.Id
        };

        // Act
        var result = await _carRepository.CreateAsync(car);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Id > 0);
        Assert.Equal("Volkswagen", result.Brand);
        Assert.Equal("Polo", result.Model);
    }

    [Fact]
    public async Task Create_Car_SetsCreatedAt()
    {
        // Arrange
        var car = new Car
        {
            Brand = "Skoda",
            Model = "Octavia",
            OwnerId = _testClient.Id
        };

        var beforeCreate = DateTime.UtcNow;

        // Act
        var result = await _carRepository.CreateAsync(car);

        // Assert
        Assert.InRange(result.CreatedAt, beforeCreate.AddSeconds(-5), DateTime.UtcNow.AddSeconds(5));
    }

    #endregion

    #region Update Tests

    [Fact]
    public async Task Update_ValidCar_UpdatesCar()
    {
        // Arrange
        var car = await CreateTestCarAsync("BMW", "X5");
        car.Color = "Синий";
        car.ProductionYear = 2022;

        // Act
        await _carRepository.UpdateAsync(car);

        // Assert
        var updated = await _carRepository.GetByIdAsync(car.Id);
        Assert.NotNull(updated);
        Assert.Equal("Синий", updated.Color);
        Assert.Equal(2022, updated.ProductionYear);
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_ValidId_DeletesCar()
    {
        // Arrange
        var car = await CreateTestCarAsync("Audi", "A6");

        // Act
        await _carRepository.DeleteAsync(car.Id);

        // Assert
        var result = await _carRepository.GetByIdAsync(car.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task Delete_InvalidId_DoesNothing()
    {
        // Act & Assert (не должно выбрасывать исключений)
        await _carRepository.DeleteAsync(999);
    }

    #endregion

    #region Search Tests

    [Fact]
    public async Task Search_EmptyTerm_ReturnsAllCars()
    {
        // Arrange
        await CreateTestCarAsync("Toyota", "Camry");
        await CreateTestCarAsync("Hyundai", "Solaris");

        // Act
        var result = await _carRepository.SearchAsync("");

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Search_ByBrand_ReturnsMatchingCars()
    {
        // Arrange
        await CreateTestCarAsync("Toyota", "Camry");
        await CreateTestCarAsync("Hyundai", "Solaris");

        // Act
        var result = await _carRepository.SearchAsync("Toyota");

        // Assert
        Assert.Single(result);
        Assert.Equal("Toyota", result[0].Brand);
    }

    [Fact]
    public async Task Search_ByModel_ReturnsMatchingCars()
    {
        // Arrange
        await CreateTestCarAsync("Toyota", "Camry");
        await CreateTestCarAsync("Toyota", "Corolla");

        // Act
        var result = await _carRepository.SearchAsync("Camry");

        // Assert
        Assert.Single(result);
        Assert.Equal("Camry", result[0].Model);
    }

    [Fact]
    public async Task Search_ByStateMark_ReturnsMatchingCars()
    {
        // Arrange
        var car = await CreateTestCarAsync("Kia", "Rio");
        car.StateMark = "В002ВВ 777";
        await _carRepository.UpdateAsync(car);

        // Act
        var result = await _carRepository.SearchAsync("В002ВВ");

        // Assert
        Assert.Single(result);
        Assert.Equal("В002ВВ 777", result[0].StateMark);
    }

    [Fact]
    public async Task Search_ByVinNumber_ReturnsMatchingCars()
    {
        // Arrange
        var car = await CreateTestCarAsync("Ford", "Focus");
        car.VinNumber = "TESTVIN123456789";
        await _carRepository.UpdateAsync(car);

        // Act
        var result = await _carRepository.SearchAsync("TESTVIN");

        // Assert
        Assert.Single(result);
        Assert.Equal("TESTVIN123456789", result[0].VinNumber);
    }

    [Fact]
    public async Task Search_ByColor_ReturnsMatchingCars()
    {
        // Arrange
        var car = await CreateTestCarAsync("Mazda", "CX-5");
        car.Color = "Красный";
        await _carRepository.UpdateAsync(car);

        // Act
        var result = await _carRepository.SearchAsync("Красный");

        // Assert
        Assert.Single(result);
        Assert.Equal("Красный", result[0].Color);
    }

    #endregion

    #region Helper Methods

    private async Task<Car> CreateTestCarAsync(string brand, string model)
    {
        var car = new Car
        {
            Brand = brand,
            Model = model,
            OwnerId = _testClient.Id
        };

        return await _carRepository.CreateAsync(car);
    }

    #endregion

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}
