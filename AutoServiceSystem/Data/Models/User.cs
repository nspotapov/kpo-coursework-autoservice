namespace Data.Models;

/// <summary>
/// Пользователь системы (администратор или менеджер)
/// </summary>
public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? Phone { get; set; }
    public DateTime? BirthDate { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Полное ФИО
    /// </summary>
    public string FullName => $"{LastName} {FirstName}{(MiddleName != null ? $" {MiddleName}" : "")}";

    // Навигационные свойства
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
