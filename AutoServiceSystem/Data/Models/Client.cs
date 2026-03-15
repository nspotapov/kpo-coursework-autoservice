namespace Data.Models;

/// <summary>
/// Клиент автосервиса
/// </summary>
public class Client
{
    public int Id { get; set; }
    public ClientType Type { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Inn { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Полное ФИО
    /// </summary>
    public string FullName => $"{LastName} {FirstName}{(MiddleName != null ? $" {MiddleName}" : "")}";

    // Навигационные свойства
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
