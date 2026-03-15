using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data;

/// <summary>
/// Контекст базы данных для ИС Автосервис
/// </summary>
public class AutoserviceDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderService> OrderServices { get; set; }
    public DbSet<OrderPart> OrderParts { get; set; }
    public DbSet<Check> Checks { get; set; }

    public AutoserviceDbContext()
    {
    }

    public AutoserviceDbContext(DbContextOptions<AutoserviceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Явное указание имен таблиц (в нижнем регистре)
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Master>().ToTable("masters");
        modelBuilder.Entity<Client>().ToTable("clients");
        modelBuilder.Entity<Car>().ToTable("cars");
        modelBuilder.Entity<Service>().ToTable("services");
        modelBuilder.Entity<Part>().ToTable("parts");
        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<OrderService>().ToTable("order_services");
        modelBuilder.Entity<OrderPart>().ToTable("order_parts");
        modelBuilder.Entity<Check>().ToTable("checks");

        // Конфигурация User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).IsRequired().HasConversion<string>();
            entity.HasIndex(e => e.Username).IsUnique();
        });

        // Конфигурация Master
        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ExperienceYears).HasDefaultValue(0);
            entity.HasIndex(e => e.IsActive);
        });

        // Конфигурация Client
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Type).IsRequired().HasConversion<string>();
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phone).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            
            // Конвертируем enum в lowercase строку для БД
            entity.Property(e => e.Type)
                  .HasConversion(
                      v => v == ClientType.Individual ? "individual" : "legal",
                      v => v == "individual" ? ClientType.Individual : ClientType.Legal);
        });

        // Конфигурация Car
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Brand).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
            entity.Property(e => e.StateMark).HasMaxLength(20);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.VinNumber).HasMaxLength(17);
            
            entity.HasOne(e => e.Owner)
                  .WithMany()
                  .HasForeignKey(e => e.OwnerId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // Конфигурация Service
        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Price).IsRequired().HasPrecision(10, 2);
        });

        // Конфигурация Part
        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Article).HasMaxLength(50);
            entity.Property(e => e.Price).IsRequired().HasPrecision(10, 2);
            entity.HasIndex(e => e.Article).IsUnique();
        });

        // Конфигурация Order
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Status).IsRequired().HasConversion<string>();
            entity.Property(e => e.TotalPrice).HasPrecision(10, 2);
            entity.HasIndex(e => e.OrderNumber).IsUnique();
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.ServiceDateTime);
            entity.HasIndex(e => e.MasterId);

            entity.HasOne(e => e.Client)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(e => e.ClientId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Car)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(e => e.CarId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Master)
                  .WithMany(m => m.Orders)
                  .HasForeignKey(e => e.MasterId)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.Manager)
                  .WithMany(m => m.Orders)
                  .HasForeignKey(e => e.ManagerId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Конфигурация OrderService
        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Price).IsRequired().HasPrecision(10, 2);
            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderServices)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Service)
                  .WithMany(s => s.OrderServices)
                  .HasForeignKey(e => e.ServiceId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Конфигурация OrderPart
        modelBuilder.Entity<OrderPart>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Price).IsRequired().HasPrecision(10, 2);
            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderParts)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Part)
                  .WithMany(p => p.OrderParts)
                  .HasForeignKey(e => e.PartId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Конфигурация Check
        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CheckNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.ClientName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CarInfo).IsRequired().HasMaxLength(200);
            entity.Property(e => e.MasterName).HasMaxLength(200);
            entity.Property(e => e.ManagerName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ServicesTotal).HasPrecision(10, 2);
            entity.Property(e => e.PartsTotal).HasPrecision(10, 2);
            entity.Property(e => e.TotalAmount).HasPrecision(10, 2);
            entity.HasIndex(e => e.CheckNumber).IsUnique();
            entity.HasIndex(e => e.OrderId).IsUnique();

            entity.HasOne(e => e.Order)
                  .WithOne(o => o.Check)
                  .HasForeignKey<Check>(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Настройка маппинга свойств (имена столбцов в snake_case)
        // Должно быть ПОСЛЕ всех конфигураций сущностей
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                // Преобразуем CamelCase в snake_case (CreatedAt -> created_at)
                var columnName = ToSnakeCase(property.Name);
                property.SetColumnName(columnName);
            }
        }
    }

    /// <summary>
    /// Преобразует CamelCase в snake_case
    /// </summary>
    private static string ToSnakeCase(string name)
    {
        return string.Concat(
            name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())
        ).ToLower();
    }
}
