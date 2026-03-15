namespace Data.Models;

/// <summary>
/// Услуга автосервиса
/// </summary>
public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
    public bool IsActive { get; set; } = true;

    // Навигационные свойства
    public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
}
