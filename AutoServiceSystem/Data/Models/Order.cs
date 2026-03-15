namespace Data.Models;

/// <summary>
/// Заявка на обслуживание (заказ-наряд)
/// </summary>
public class Order
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public int ClientId { get; set; }
    public int CarId { get; set; }
    public int? MasterId { get; set; }
    public DateTime ServiceDateTime { get; set; }
    public OrderStatus Status { get; set; }
    public int ManagerId { get; set; }
    public decimal? TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Навигационные свойства
    public Client Client { get; set; } = null!;
    public Car Car { get; set; } = null!;
    public Master? Master { get; set; }
    public User Manager { get; set; } = null!;
    public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
    public ICollection<OrderPart> OrderParts { get; set; } = new List<OrderPart>();
    public Check? Check { get; set; }
}
