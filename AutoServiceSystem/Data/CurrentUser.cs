using Data.Models;

namespace Data;

/// <summary>
/// Текущий авторизованный пользователь
/// </summary>
public static class CurrentUser
{
    private static User? _currentUser;

    /// <summary>
    /// Текущий пользователь
    /// </summary>
    public static User? User
    {
        get => _currentUser;
        set => _currentUser = value;
    }

    /// <summary>
    /// Авторизован ли пользователь
    /// </summary>
    public static bool IsAuthenticated => _currentUser != null;

    /// <summary>
    /// Является ли текущий пользователь администратором
    /// </summary>
    public static bool IsAdmin => _currentUser?.Role == UserRole.Admin;

    /// <summary>
    /// Является ли текущий пользователь менеджером
    /// </summary>
    public static bool IsManager => _currentUser?.Role == UserRole.Manager;

    /// <summary>
    /// Очистить данные текущего пользователя
    /// </summary>
    public static void Logout()
    {
        _currentUser = null;
    }

    /// <summary>
    /// Установить текущего пользователя
    /// </summary>
    public static void Login(User user)
    {
        _currentUser = user;
    }
}
