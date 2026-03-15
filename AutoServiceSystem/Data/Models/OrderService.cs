namespace Data.Models;

/// <summary>
/// Услуга в заявке (связь многие-ко-многим)
/// </summary>
public class OrderService
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ServiceId { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    // Навигационные свойства
    public Order Order { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
