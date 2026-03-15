namespace Data.Models;

/// <summary>
/// Статус заявки
/// </summary>
public enum OrderStatus
{
    Pending,      // Ожидает исполнения
    InProgress,   // В работе
    Completed,    // Выполнена
    Overdue,      // Просрочена
    Cancelled     // Отменена
}
