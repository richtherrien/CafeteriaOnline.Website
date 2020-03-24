using CafeteriaOnline.Website.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CafeteriaOnline.Website.Data
{
    public class CafeteriaContext : DbContext
    {

        public CafeteriaContext() : base("aspnet-CafeteriaOnline.Website")
        {
        }

        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Caterer> Caterers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<CafeteriaAddress> CafeteriaAddresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MealConfiguration> MealConfigurations { get; set; }
        public DbSet<CafeteriaFood> CafeteriaFoods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}