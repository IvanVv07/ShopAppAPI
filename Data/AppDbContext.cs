using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Models;

namespace ShopAppAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tablas de la base
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------
            // Product.Price decimal(18,2)
            // -------------------------
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // -------------------------
            // Order (1) -> OrderItems (N)
            // -------------------------
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // -------------------------
            // Product (1) -> OrderItems (N)
            // -------------------------
            modelBuilder.Entity<Product>()
                .HasMany<OrderItem>()
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // -------------------------
            // User (Empresa) -> Products
            // -------------------------
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // -------------------------
            // User (Cliente) -> Orders
            // -------------------------
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // -------------------------
            // Seed Admin inicial
            // -------------------------
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@shop.com",
                Password = "admin123",
                Role = "Admin"
            });
        }
    }
}