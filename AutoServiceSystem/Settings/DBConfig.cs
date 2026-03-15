namespace Settings;

/// <summary>
/// Конфигурация подключения к базе данных
/// </summary>
public static class DBConfig
{
    /// <summary>
    /// Строка подключения к PostgreSQL
    /// </summary>
    public static string ConnectionString =>
        "Host=localhost;Port=5432;Database=autoservice;Username=postgres;Password=postgres";

    /// <summary>
    /// Имя базы данных
    /// </summary>
    public static string DatabaseName => "autoservice";

    /// <summary>
    /// Сервер базы данных
    /// </summary>
    public static string Host => "localhost";

    /// <summary>
    /// Порт базы данных
    /// </summary>
    public static int Port => 5432;
}
