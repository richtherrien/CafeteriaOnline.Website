﻿
using CafeteriaOnline.Website.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CafeteriaOnline.Website.Data
{
    public class CafeteriaContext : IdentityDbContext<ApplicationUser>
    {

        public CafeteriaContext(DbContextOptions<CafeteriaContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Caterer> Caterers { get; set; }
        public DbSet<CafeteriaAddress> CafeteriaAddresses { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealConfiguration> MealConfigurations { get; set; }
        public DbSet<CafeteriaFood> CafeteriaFoods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<CafeteriaAddress>().ToTable("CafeteriaAddress");
            modelBuilder.Entity<Meal>().ToTable("Meal");
            modelBuilder.Entity<MealConfiguration>().ToTable("MealConfiguration");
            modelBuilder.Entity<CafeteriaFood>().ToTable("CafeteriaFood");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
        }
    }
}
