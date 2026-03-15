namespace Data.Models;

/// <summary>
/// Автомобиль
/// </summary>
public class Car
{
    public int Id { get; set; }
    public int? OwnerId { get; set; } // Владелец (клиент)
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string? StateMark { get; set; }
    public int? ProductionYear { get; set; }
    public string? Color { get; set; }
    public string? VinNumber { get; set; }
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Марка и модель
    /// </summary>
    public string BrandModel => $"{Brand} {Model}";

    // Навигационные свойства
    public Client? Owner { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
