namespace Data.Models;

/// <summary>
/// Запчасть в заявке (связь многие-ко-многим)
/// </summary>
public class OrderPart
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int PartId { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    // Навигационные свойства
    public Order Order { get; set; } = null!;
    public Part Part { get; set; } = null!;
}
