namespace Data.Models;

/// <summary>
/// Запчасть
/// </summary>
public class Part
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Article { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public bool IsActive { get; set; } = true;

    // Навигационные свойства
    public ICollection<OrderPart> OrderParts { get; set; } = new List<OrderPart>();
}
