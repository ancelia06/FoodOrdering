using Food_Ordering_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Food_Ordering_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> Menu { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryAgent> DeliveryAgents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure decimal precision for Price, Discount, Total
            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Discount)
                .HasPrecision(10, 2);

            base.OnModelCreating(modelBuilder);
        }
    }

}

