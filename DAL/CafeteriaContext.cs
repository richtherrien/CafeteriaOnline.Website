using CafeteriaOnline.Website.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CafeteriaOnline.Website.DAL
{
    public class CafeteriaContext : DbContext
    {

        public CafeteriaContext() : base("CafeteriaContext")
        {
        }

        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<Caterer> Caterers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BaseMealIngredient> BaseMealIngredients { get; set; }
        public DbSet<ConfigMealIngredient> ConfigMealIngredients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}