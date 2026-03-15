Console.WriteLine($"admin hash: {BCrypt.Net.BCrypt.HashPassword("admin")}");
Console.WriteLine($"manager hash: {BCrypt.Net.BCrypt.HashPassword("manager")}");
Console.WriteLine("\nСкопируй эти хэши в init.sql!");
