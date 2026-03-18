using Data;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Repositories;

/// <summary>
/// Тесты для OrderRepository
/// </summary>
public class OrderRepositoryTests : IDisposable
{
    private readonly AutoserviceDbContext _dbContext;
    private readonly OrderRepository _orderRepository;
    private readonly Client _testClient;
    private readonly Car _testCar;
    private readonly Master _testMaster;
    private readonly User _testManager;

    public OrderRepositoryTests()
    {
        // Инициализация InMemory базы данных для тестов
        var options = new DbContextOptionsBuilder<AutoserviceDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_Order_{Guid.NewGuid()}")
            .Options;

        _dbContext = new AutoserviceDbContext(options);
        _orderRepository = new OrderRepository(_dbContext);

        // Создаём тестовые данные
        _testClient = new Client
        {
            Type = ClientType.Individual,
            LastName = "Клиентов",
            FirstName = "Клиент",
            Phone = "+7 (900) 111-11-11"
        };
        _dbContext.Clients.Add(_testClient);

        _testCar = new Car
        {
            Brand = "Toyota",
            Model = "Camry",
            OwnerId = _testClient.Id
        };
        _dbContext.Cars.Add(_testCar);

        _testMaster = new Master
        {
            LastName = "Мастеров",
            FirstName = "Мастер",
            Phone = "+7 (900) 222-22-22"
        };
        _dbContext.Masters.Add(_testMaster);

        _testManager = new User
        {
            Username = "manager_test",
            Password = "test",
            LastName = "Менеджеров",
            FirstName = "Менеджер",
            Role = UserRole.Manager
        };
        _dbContext.Users.Add(_testManager);

        _dbContext.SaveChanges();
    }

    #region GetAll Tests

    [Fact]
    public async Task GetAll_EmptyDatabase_ReturnsEmptyList()
    {
        // Act
        var result = await _orderRepository.GetAllAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAll_WithOrders_ReturnsAllOrders()
    {
        // Arrange
        await CreateTestOrderAsync(OrderStatus.Pending);
        await CreateTestOrderAsync(OrderStatus.Completed);

        // Act
        var result = await _orderRepository.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_ValidId_ReturnsOrder()
    {
        // Arrange
        var order = await CreateTestOrderAsync(OrderStatus.Pending);

        // Act
        var result = await _orderRepository.GetByIdAsync(order.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(order.OrderNumber, result.OrderNumber);
    }

    [Fact]
    public async Task GetById_InvalidId_ReturnsNull()
    {
        // Act
        var result = await _orderRepository.GetByIdAsync(999);

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region Create Tests

    [Fact]
    public async Task Create_ValidOrder_AddsOrder()
    {
        // Arrange
        var order = new Order
        {
            OrderNumber = "ORD-TEST-001",
            ClientId = _testClient.Id,
            CarId = _testCar.Id,
            MasterId = _testMaster.Id,
            ManagerId = _testManager.Id,
            ServiceDateTime = DateTime.Now.AddDays(1),
            Status = OrderStatus.Pending
        };

        // Act
        var result = await _orderRepository.CreateAsync(order);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Id > 0);
        Assert.Equal("ORD-TEST-001", result.OrderNumber);
        Assert.Equal(OrderStatus.Pending, result.Status);
    }

    [Fact]
    public async Task Create_Order_SetsTimestamps()
    {
        // Arrange
        var order = new Order
        {
            OrderNumber = "ORD-TEST-002",
            ClientId = _testClient.Id,
            CarId = _testCar.Id,
            ManagerId = _testManager.Id,
            ServiceDateTime = DateTime.Now.AddDays(1),
            Status = OrderStatus.Pending
        };

        var beforeCreate = DateTime.UtcNow;

        // Act
        var result = await _orderRepository.CreateAsync(order);

        // Assert
        Assert.InRange(result.CreatedAt, beforeCreate.AddSeconds(-5), DateTime.UtcNow.AddSeconds(5));
        Assert.InRange(result.UpdatedAt, beforeCreate.AddSeconds(-5), DateTime.UtcNow.AddSeconds(5));
    }

    #endregion

    #region Update Tests

    [Fact]
    public async Task Update_ValidOrder_UpdatesOrder()
    {
        // Arrange
        var order = await CreateTestOrderAsync(OrderStatus.Pending);
        order.Status = OrderStatus.Completed;
        order.TotalPrice = 5000;

        // Act
        await _orderRepository.UpdateAsync(order);

        // Assert
        var updated = await _orderRepository.GetByIdAsync(order.Id);
        Assert.NotNull(updated);
        Assert.Equal(OrderStatus.Completed, updated.Status);
        Assert.Equal(5000, updated.TotalPrice);
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_ValidId_DeletesOrder()
    {
        // Arrange
        var order = await CreateTestOrderAsync(OrderStatus.Pending);

        // Act
        await _orderRepository.DeleteAsync(order.Id);

        // Assert
        var result = await _orderRepository.GetByIdAsync(order.Id);
        Assert.Null(result);
    }

    [Fact]
    public async Task Delete_InvalidId_DoesNothing()
    {
        // Act & Assert (не должно выбрасывать исключений)
        await _orderRepository.DeleteAsync(999);
    }

    #endregion

    #region GetByStatus Tests

    [Fact]
    public async Task GetByStatus_ValidStatus_ReturnsMatchingOrders()
    {
        // Arrange
        await CreateTestOrderAsync(OrderStatus.Pending);
        await CreateTestOrderAsync(OrderStatus.Pending);
        await CreateTestOrderAsync(OrderStatus.Completed);

        // Act
        var result = await _orderRepository.GetByStatusAsync(OrderStatus.Pending);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.All(result, o => Assert.Equal(OrderStatus.Pending, o.Status));
    }

    #endregion

    #region GetByDateRange Tests

    [Fact]
    public async Task GetByDateRange_ValidRange_ReturnsMatchingOrders()
    {
        // Arrange
        var order1 = await CreateTestOrderAsync(OrderStatus.Pending, DateTime.Now.AddDays(-5));
        var order2 = await CreateTestOrderAsync(OrderStatus.Pending, DateTime.Now);
        var order3 = await CreateTestOrderAsync(OrderStatus.Pending, DateTime.Now.AddDays(5));

        // Act
        var result = await _orderRepository.GetByDateRangeAsync(
            DateTime.Now.AddDays(-1),
            DateTime.Now.AddDays(1));

        // Assert
        Assert.Single(result);
        Assert.Equal(order2.OrderNumber, result[0].OrderNumber);
    }

    #endregion

    #region Search Tests

    [Fact]
    public async Task Search_EmptyTerm_ReturnsAllOrders()
    {
        // Arrange
        await CreateTestOrderAsync(OrderStatus.Pending);
        await CreateTestOrderAsync(OrderStatus.Completed);

        // Act
        var result = await _orderRepository.SearchAsync("");

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Search_ByOrderNumber_ReturnsMatchingOrders()
    {
        // Arrange
        var order = await CreateTestOrderAsync(OrderStatus.Pending);
        order.OrderNumber = "ORD-SPECIFIC-123";
        await _orderRepository.UpdateAsync(order);

        // Act
        var result = await _orderRepository.SearchAsync("ORD-SPECIFIC-123");

        // Assert
        Assert.Single(result);
        Assert.Equal("ORD-SPECIFIC-123", result[0].OrderNumber);
    }

    [Fact]
    public async Task Search_ByClientLastName_ReturnsMatchingOrders()
    {
        // Arrange
        var order = await CreateTestOrderAsync(OrderStatus.Pending);
        
        // Act
        var result = await _orderRepository.SearchAsync("Клиентов");

        // Assert
        Assert.Single(result);
        Assert.Equal("Клиентов", result[0].Client.LastName);
    }

    #endregion

    #region UpdateStatus Tests

    [Fact]
    public async Task UpdateStatus_ValidId_UpdatesStatus()
    {
        // Arrange
        var order = await CreateTestOrderAsync(OrderStatus.Pending);

        // Act
        await _orderRepository.UpdateStatusAsync(order.Id, OrderStatus.Completed);

        // Assert
        var updated = await _orderRepository.GetByIdAsync(order.Id);
        Assert.NotNull(updated);
        Assert.Equal(OrderStatus.Completed, updated.Status);
    }

    [Fact]
    public async Task UpdateStatus_InvalidId_DoesNothing()
    {
        // Act & Assert (не должно выбрасывать исключений)
        await _orderRepository.UpdateStatusAsync(999, OrderStatus.Completed);
    }

    #endregion

    #region Helper Methods

    private async Task<Order> CreateTestOrderAsync(OrderStatus status, DateTime? serviceDateTime = null)
    {
        var order = new Order
        {
            OrderNumber = $"ORD-{Guid.NewGuid()}",
            ClientId = _testClient.Id,
            CarId = _testCar.Id,
            MasterId = _testMaster.Id,
            ManagerId = _testManager.Id,
            ServiceDateTime = serviceDateTime ?? DateTime.Now,
            Status = status
        };

        return await _orderRepository.CreateAsync(order);
    }

    #endregion

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}
