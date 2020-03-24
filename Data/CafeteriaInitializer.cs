using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CafeteriaOnline.Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafeteriaOnline.Website.Data
{
    public class CafeteriaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CafeteriaContext>
    {
        protected override void Seed(CafeteriaContext context)
        {
            var companies = new List<Company>
            {
                new Company{Name="Kethesda Corp.", Telephone="123-456-7890", CompanyCode="keth123d91", OrganizerID=1},
                new Company{Name="Geocoder Ltd.",  Telephone="456-687-7890", CompanyCode="geoc1f818s", OrganizerID=2},
                new Company{Name="Stefan & Co.",   Telephone="654-456-8542", CompanyCode="stef4f8s8h", OrganizerID=3},
            };

            companies.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();

            var cafeteriaAddresses = new List<CafeteriaAddress>
            {
                new CafeteriaAddress{StreetAddress="350 Victoria St", City="Toronto", Province="ON", Country="Canada", PostalCode="M5B 2K3", CompanyID=1, CashierID=1},
                new CafeteriaAddress{StreetAddress="132 Gould St", City="Toronto", Province="ON", Country="Canada", PostalCode="M5B 2K3", CompanyID=2, CashierID=1},
                new CafeteriaAddress{StreetAddress="431 Younge St", City="Toronto", Province="ON", Country="Canada", PostalCode="M5B 2K3", CompanyID=3, CashierID=1},
            };

            cafeteriaAddresses.ForEach(s => context.CafeteriaAddresses.Add(s));
            context.SaveChanges();

            var passwordHasher = new PasswordHasher();
            var employees = new List<Employee>
            {
                new Employee{UserName="Logan", Email = "logan@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Logan", LastName="James", CompanyID=1, CafeteriaAddressID=1},
                new Employee{UserName="Blazor", Email = "blazor@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Blazor", LastName="Raze", CompanyID=1, CafeteriaAddressID=1},
                new Employee{UserName="Mance", Email = "mance@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Mance", LastName="Raider", CompanyID=1, CafeteriaAddressID=1},
                new Employee{UserName="Maxwell", Email = "maxwell@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Maxwell", LastName="Cruze", CompanyID=2, CafeteriaAddressID=2},
                new Employee{UserName="Janet", Email = "janet@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Janet", LastName="Planet", CompanyID=2, CafeteriaAddressID=2},
                new Employee{UserName="Bobert", Email = "bobert@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Bobert", LastName="Simth", CompanyID=2, CafeteriaAddressID=2},
                new Employee{UserName="Stefan", Email = "stefan@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Stefan", LastName="Kelly", CompanyID=3, CafeteriaAddressID=3},
                new Employee{UserName="Brackston", Email = "brackston@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Brackston", LastName="Janor", CompanyID=3, CafeteriaAddressID=3},
                new Employee{UserName="Chad", Email = "chad@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Chad", LastName="Dickensten", CompanyID=3, CafeteriaAddressID=3},
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var organizers = new List<Organizer>
            {
                new Organizer{UserName="Carol", Email = "carol@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Carol", LastName="Sherrly", CompanyID=1, CafeteriaAddressID=1},
                new Organizer{UserName="Jane", Email = "jane@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Jane", LastName="Mattenson", CompanyID=2, CafeteriaAddressID=2},
                new Organizer{UserName="Kenny", Email = "kenny@email.com", PasswordHash = passwordHasher.HashPassword("password"),  FirstName="Kenny", LastName="Rogers", CompanyID=3, CafeteriaAddressID=3},
            };

            organizers.ForEach(s => context.Organizer.Add(s));
            context.SaveChanges();

            var caterers = new List<Caterer>
            {
                new Caterer{UserName="Mancy", Email = "mancy@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Mancy", LastName="Raider"},
            };

            caterers.ForEach(s => context.Caterers.Add(s));
            context.SaveChanges();

            var cashiers = new List<Cashier>
            {
                new Cashier{UserName="Cathy", Email = "mancy@email.com", PasswordHash = passwordHasher.HashPassword("password"), FirstName="Cathy", LastName="Cashier"},
            };

            cashiers.ForEach(s => context.Cashiers.Add(s));

            context.SaveChanges();

            var meals = new List<Meal>
            {
                new Meal{CatererID=1, Name="Burger", MealType=MealType.Entrée, Description="A classic hamburger", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.mcdonalds.com/content/dam/usa/nfl/nutrition/items/regular/desktop/t-mcdonalds-qpc-deluxe-burger.jpg" },
                new Meal{CatererID=1, Name="Hot Dog", MealType=MealType.Entrée, Description="100% Beef Hot Dog", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://image.shutterstock.com/image-photo/hot-dog-mustard-ketchup-side-260nw-683413162.jpg" },
                new Meal{CatererID=1, Name="Chicken Nuggets", MealType=MealType.Entrée, Description="Chicken nuggets cooked with love", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://food.fnr.sndimg.com/content/dam/images/food/fullset/2013/9/12/1/FN_Picky-Eaters-Chicken-Nuggets_s4x3.jpg.rend.hgtvcom.616.462.suffix/1383770571120.jpeg" },
                new Meal{CatererID=1, Name="Pizza", MealType=MealType.Entrée, Description="American style pizza", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.insauga.com/sites/default/files/imagecache/lead-image-full/article/2014/11/luca2.jpg" },
                new Meal{CatererID=1, Name="Calzone", MealType=MealType.Entrée, Description="This a nice calzone", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://images-gmi-pmc.edge-generalmills.com/22fba15f-7711-49e7-8948-e0496ccc1c8e.jpg" },
                new Meal{CatererID=1, Name="Meat Loaf", MealType=MealType.Entrée, Description="Made with beef", 
                    ValidUntil=new DateTime(2020, 2, 25), ImageUrl ="https://food.fnr.sndimg.com/content/dam/images/food/fullset/2011/7/26/2/BX0304_meat-loaf_s4x3.jpg.rend.hgtvcom.826.620.suffix/1404148970653.jpeg" },

                new Meal{CatererID=1, Name="Milkshake", MealType=MealType.Beverage, Description="A thick and creamy shake", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://bakingmischief.com/wp-content/uploads/2019/07/how-to-make-a-milkshake-image-square.jpg" },
                new Meal{CatererID=1, Name="Iced Coffee", MealType=MealType.Beverage, Description="Stored in a impressive container", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://buildyourbite.com/wp-content/uploads/2018/05/how-to-make-iced-coffee-31-735x1015.jpg" },


                new Meal{CatererID=1, Name="Bruschetta", MealType=MealType.Appetizer, Description="Double Tomato Bruschetta", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.cookingclassy.com/wp-content/uploads/2019/07/bruschetta-2.jpg" },
                new Meal{CatererID=1, Name="Coconut Shrimp", MealType=MealType.Appetizer, Description="Dipped in coconut beer batter", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://cafedelites.com/wp-content/uploads/2019/12/Coconut-Shrimp-2-500x500.jpg" },


                new Meal{CatererID=1, Name="Ice Cream", MealType=MealType.Dessert, Description="A delicious frozen treat", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.simplyrecipes.com/wp-content/uploads/2006/06/French-Vanilla-IceCream-LEAD-1.jpg" },
                new Meal{CatererID=1, Name="Cake", MealType=MealType.Dessert, Description="Yummy birthday cake", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.cookingclassy.com/wp-content/uploads/2019/07/birthday-cake-4.jpg" },


                new Meal{CatererID=1, Name="Salad", MealType=MealType.Greens, Description="It has iceberg lettuce", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://food.fnr.sndimg.com/content/dam/images/food/fullset/2004/1/23/1/ss1d27_mixed_green_salad.jpg.rend.hgtvcom.826.620.suffix/1386276604828.jpeg" },
                new Meal{CatererID=1, Name="Green Beans", MealType=MealType.Greens, Description="Aren't we just two peas in pod", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.simplyrecipes.com/wp-content/uploads/2009/11/green-beans-almonds-thyme-1800-2.jpg" },

                new Meal{CatererID=1, Name="Cookie", MealType=MealType.Pastry, Description="A chocolate chip cookie", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://images-gmi-pmc.edge-generalmills.com/087d17eb-500e-4b26-abd1-4f9ffa96a2c6.jpg" },
                new Meal{CatererID=1, Name="Muffin", MealType=MealType.Pastry, Description="A nice muffin to have", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.handletheheat.com/wp-content/uploads/2009/09/Chocolate-Chip-Muffins-SQUARE.jpg" },
            };

            meals.ForEach(s => context.Meals.Add(s));
            context.SaveChanges();

            var mealConfiguration = new List<MealConfiguration>
            {
                new MealConfiguration{MealID=1, Ingredients="buns,hamburger,ketchup", Price=5.99m},
                new MealConfiguration{MealID=1, Ingredients="buns,hamburger,ketchup,pickels", Price=5.99m},
                new MealConfiguration{MealID=2, Ingredients="buns,hamburger,ketchup", Price=3.50m},
                new MealConfiguration{MealID=2, Ingredients="buns,hamburger,ketchup,pickels", Price=3.99m},
                new MealConfiguration{MealID=3, Ingredients="chicken,sweet&sour", Price=5.99m},
                new MealConfiguration{MealID=3, Ingredients="chicken,barbeque", Price=5.99m},
                new MealConfiguration{MealID=4, Ingredients="dough,sauce,cheese,pepperoni", Price=2.99m},
                new MealConfiguration{MealID=4, Ingredients="dough,sauce,pepperoni", Price=2.50m},
                new MealConfiguration{MealID=5, Ingredients="dough,sauce,pepperoni", Price=4.99m},
                new MealConfiguration{MealID=6, Ingredients="meat,loaf", Price=2.50m},
                new MealConfiguration{MealID=7, Ingredients="milk,vanilla,cream", Price=4.50m},
                new MealConfiguration{MealID=8, Ingredients="ice,coffee", Price=2.99m},
                new MealConfiguration{MealID=9, Ingredients="bread,tomato", Price=3.99m},
                new MealConfiguration{MealID=10, Ingredients="shrimp,breaded", Price=3.99m},
                new MealConfiguration{MealID=11, Ingredients="milk,cream", Price=4.99m},
                new MealConfiguration{MealID=12, Ingredients="sugar,icing", Price=3.99m},
                new MealConfiguration{MealID=13, Ingredients="lettuce,tomato,pepper", Price=6.50m},
                new MealConfiguration{MealID=14, Ingredients="beans", Price=1.99m},
                new MealConfiguration{MealID=15, Ingredients="dough,chocolatechips", Price=3.50m},
                new MealConfiguration{MealID=16, Ingredients="choclate", Price=2.99m},
            };

            mealConfiguration.ForEach(s => context.MealConfigurations.Add(s));
            context.SaveChanges();


            var orders = new List<Order>
            {
                new Order{EmployeeID=1, MealConfigurationID=1, OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=2, MealConfigurationID=3, OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=3, MealConfigurationID=2, OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Account, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=4, MealConfigurationID=7, OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=5, MealConfigurationID=5, OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=6, MealConfigurationID=8, OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Unpaid, OrderStatus=OrderStatus.Complete, Quantity=1},

                new Order{EmployeeID=7, MealConfigurationID=16, OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 3, 28), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=8, MealConfigurationID=15, OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 3, 27), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=9, MealConfigurationID=14, OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 3, 28), PaidStatus=PaidStatus.Account, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=1, MealConfigurationID=15, OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 4, 1), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=2, MealConfigurationID=10, OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 4, 2), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete, Quantity=1},
                new Order{EmployeeID=3, MealConfigurationID=9, OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 4, 5), PaidStatus=PaidStatus.Unpaid, OrderStatus=OrderStatus.Complete, Quantity=1},
            };

            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
        }
    }
}