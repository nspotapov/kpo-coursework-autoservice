namespace Data.Models;

/// <summary>
/// Чек (выполненная заявка)
/// </summary>
public class Check
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string CheckNumber { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string CarInfo { get; set; } = string.Empty;
    public decimal ServicesTotal { get; set; }
    public decimal PartsTotal { get; set; }
    public decimal TotalAmount { get; set; }
    public string? MasterName { get; set; }
    public string ManagerName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // Навигационные свойства
    public Order Order { get; set; } = null!;
}
