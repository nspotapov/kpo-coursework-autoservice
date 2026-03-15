// Генерация хэшей BCrypt для паролей admin и manager

var adminHash = BCrypt.Net.BCrypt.HashPassword("admin");
var managerHash = BCrypt.Net.BCrypt.HashPassword("manager");

Console.WriteLine("=== Хэши BCrypt для init.sql ===");
Console.WriteLine();
Console.WriteLine($"-- Пароль для admin:");
Console.WriteLine($"INSERT INTO users (username, password, full_name, role) VALUES ('admin', '{adminHash}', 'Администратор Системы', 'admin');");
Console.WriteLine();
Console.WriteLine($"-- Пароль для manager:");
Console.WriteLine($"INSERT INTO users (username, password, full_name, role) VALUES ('manager', '{managerHash}', 'Менеджер Тестовый', 'manager');");
Console.WriteLine();
Console.WriteLine("Скопируй эти строки в database/init.sql и пересоздай БД!");
