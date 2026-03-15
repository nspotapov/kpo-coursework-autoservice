namespace Data.Models;

/// <summary>
/// Мастер автосервиса
/// </summary>
public class Master
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string? Phone { get; set; }
    public DateTime? BirthDate { get; set; }
    public int ExperienceYears { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Полное ФИО
    /// </summary>
    public string FullName => $"{LastName} {FirstName}{(MiddleName != null ? $" {MiddleName}" : "")}";

    // Навигационные свойства
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
