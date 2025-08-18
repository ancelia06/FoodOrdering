using FoodOrdering__API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering__API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FoodItem> FoodItems => Set<FoodItem>();
        public DbSet<DeliveryAgent> DeliveryAgents => Set<DeliveryAgent>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Decimal precision
            modelBuilder.Entity<FoodItem>().Property(f => f.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderItem>().Property(oi => oi.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>().Property(o => o.Discount).HasColumnType("decimal(18,2)");

            // Seed data
            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem { Id = 1, Name = "Pizza", Price = 250 },
                new FoodItem { Id = 2, Name = "Burger", Price = 120 },
                new FoodItem { Id = 3, Name = "Pasta", Price = 150 },
                new FoodItem { Id = 4, Name = "Sandwich", Price = 100 }
            );

            modelBuilder.Entity<DeliveryAgent>().HasData(
                new DeliveryAgent { Id = 1, Name = "Agent A" },
                new DeliveryAgent { Id = 2, Name = "Agent B" },
                new DeliveryAgent { Id = 3, Name = "Agent C" }
            );
        }

    }
}
