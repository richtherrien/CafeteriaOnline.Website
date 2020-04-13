using System;
using System.Collections.Generic;
using System.Linq;
using CafeteriaOnline.Website.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Data
{
    public static class CafeteriaInitializer
    {
        public static void Initialize(CafeteriaContext context)
        {
            // Look for any Company before seeding the database.
            if (context.Companies.Any())
            {
                return;   // DB has been seeded
            }
            var passwordHasher = new PasswordHasher();

            var caterers = new List<Caterer>
            {
                new Caterer{UserName="mancy@email.com", NormalizedUserName="MANCY@EMAIL.COM", Email = "mancy@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Mancy", LastName="Raider"},
            };

            caterers.ForEach(s => context.Caterers.Add(s));
            context.SaveChanges();

            var cashiers = new List<Cashier>
            {
                new Cashier{UserName="cathy@email.com", NormalizedUserName="CATHY@EMAIL.COM", Email = "cathy@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Cathy", LastName="Cashier"},
            };

            cashiers.ForEach(s => context.Cashiers.Add(s));
            context.SaveChanges();

            var companies = new List<Company>
            {
                new Company{Name="Kethesda Corp.", Telephone="123-456-7890", CompanyCode="keth123d91"},
                new Company{Name="Geocoder Ltd.",  Telephone="456-687-7890", CompanyCode="geoc1f818s"},
                new Company{Name="Stefan & Co.",   Telephone="654-456-8542", CompanyCode="stef4f8s8h"},
            };

            companies.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();

            var cafeteriaAddresses = new List<CafeteriaAddress>
            {
                new CafeteriaAddress{StreetAddress="350 Victoria St", City="Toronto", Province="ON", Country="Canada", PostalCode="M5B 2K3", Company = companies[0], Cashier=cashiers[0]},
                new CafeteriaAddress{StreetAddress="132 Gould St", City="Toronto", Province="ON", Country="Canada", PostalCode="M5B 2K3", Company = companies[1], Cashier=cashiers[0]},
                new CafeteriaAddress{StreetAddress="431 Younge St", City="Toronto", Province="ON", Country="Canada", PostalCode="M5B 2K3", Company = companies[2], Cashier=cashiers[0]},
            };

            cafeteriaAddresses.ForEach(s => context.CafeteriaAddresses.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{UserName="logan@email.com", NormalizedUserName="LOGAN@EMAIL.COM", Email = "logan@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Logan", LastName="James", Company=companies[0], CafeteriaAddress=cafeteriaAddresses[0]},
                new Employee{UserName="blazor@email.com", NormalizedUserName="BLAZOR@EMAIL.COM", Email = "blazor@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Blazor", LastName="Raze", Company=companies[0], CafeteriaAddress=cafeteriaAddresses[0]},
                new Employee{UserName="mance@email.com", NormalizedUserName="MANCE@EMAIL.COM", Email = "mance@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Mance", LastName="Raider", Company=companies[0], CafeteriaAddress=cafeteriaAddresses[0]},
                new Employee{UserName="maxwell@email.com", NormalizedUserName="MAXWELL@EMAIL.COM", Email = "maxwell@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Maxwell", LastName="Cruze", Company=companies[1], CafeteriaAddress=cafeteriaAddresses[1]},
                new Employee{UserName="janet@email.com", NormalizedUserName="JANET@EMAIL.COM", Email = "janet@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Janet", LastName="Planet", Company=companies[1], CafeteriaAddress=cafeteriaAddresses[1]},
                new Employee{UserName="bobert@email.com", NormalizedUserName="BOBERT@EMAIL.COM", Email = "bobert@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Bobert", LastName="Simth", Company=companies[1], CafeteriaAddress=cafeteriaAddresses[1]},
                new Employee{UserName="stefan@email.com", NormalizedUserName="STEFAN@EMAIL.COM", Email = "stefan@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Stefan", LastName="Kelly", Company=companies[2], CafeteriaAddress=cafeteriaAddresses[2]},
                new Employee{UserName="brackston@email.com", NormalizedUserName="BRACKSTON@EMAIL.COM", Email = "brackston@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Brackston", LastName="Janor", Company=companies[2], CafeteriaAddress=cafeteriaAddresses[2]},
                new Employee{UserName="chad@email.com", NormalizedUserName="CHAD@EMAIL.COM", Email = "chad@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Chad", LastName="Dickensten", Company=companies[2], CafeteriaAddress=cafeteriaAddresses[2]},
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var organizers = new List<Organizer>
            {
                new Organizer{UserName="carol@email.com", NormalizedUserName="CAROL@EMAIL.COM", Email = "carol@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Carol", LastName="Sherrly", Company=companies[0],  CafeteriaAddress=cafeteriaAddresses[0]},
                new Organizer{UserName="jane@email.com", NormalizedUserName="JANE@EMAIL.COM", Email = "jane@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"), FirstName="Jane", LastName="Mattenson", Company=companies[1],  CafeteriaAddress=cafeteriaAddresses[1]},
                new Organizer{UserName="kenny@email.com", NormalizedUserName="KENNY@EMAIL.COM", Email = "kenny@email.com", PasswordHash = passwordHasher.HashPassword("Password1!"),  FirstName="Kenny", LastName="Rogers", Company=companies[2], CafeteriaAddress=cafeteriaAddresses[2]},
            };

            organizers.ForEach(s => context.Organizers.Add(s));
            context.SaveChanges();

            caterers.ForEach(s => {
                AddToUsersRoles(s, context, 0).Wait();
            });

            employees.ForEach(s => {
                AddToUsersRoles(s, context, 1).Wait();
            });

            organizers.ForEach(s => {
                AddToUsersRoles(s, context, 2).Wait();
            });

            cashiers.ForEach(s => {
                AddToUsersRoles(s, context, 3).Wait();
            });
            var meals = new List<Meal>
            {
                new Meal{Caterer=caterers[0], Name="Burger", MealType=MealType.Entrée, Description="A classic hamburger", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.mcdonalds.com/content/dam/usa/nfl/nutrition/items/regular/desktop/t-mcdonalds-qpc-deluxe-burger.jpg" },
                new Meal{Caterer=caterers[0], Name="Hot Dog", MealType=MealType.Entrée, Description="100% Beef Hot Dog", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://image.shutterstock.com/image-photo/hot-dog-mustard-ketchup-side-260nw-683413162.jpg" },
                new Meal{Caterer=caterers[0], Name="Chicken Nuggets", MealType=MealType.Entrée, Description="Chicken nuggets cooked with love", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://food.fnr.sndimg.com/content/dam/images/food/fullset/2013/9/12/1/FN_Picky-Eaters-Chicken-Nuggets_s4x3.jpg.rend.hgtvcom.616.462.suffix/1383770571120.jpeg" },
                new Meal{Caterer=caterers[0], Name="Pizza", MealType=MealType.Entrée, Description="American style pizza", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.insauga.com/sites/default/files/imagecache/lead-image-full/article/2014/11/luca2.jpg" },
                new Meal{Caterer=caterers[0], Name="Calzone", MealType=MealType.Entrée, Description="This a nice calzone", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://images-gmi-pmc.edge-generalmills.com/22fba15f-7711-49e7-8948-e0496ccc1c8e.jpg" },
                new Meal{Caterer=caterers[0], Name="Meat Loaf", MealType=MealType.Entrée, Description="Made with beef", 
                    ValidUntil=new DateTime(2020, 2, 25), ImageUrl ="https://food.fnr.sndimg.com/content/dam/images/food/fullset/2011/7/26/2/BX0304_meat-loaf_s4x3.jpg.rend.hgtvcom.826.620.suffix/1404148970653.jpeg" },

                new Meal{Caterer=caterers[0], Name="Milkshake", MealType=MealType.Beverage, Description="A thick and creamy shake", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://bakingmischief.com/wp-content/uploads/2019/07/how-to-make-a-milkshake-image-square.jpg" },
                new Meal{Caterer=caterers[0], Name="Iced Coffee", MealType=MealType.Beverage, Description="Stored in a impressive container", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://buildyourbite.com/wp-content/uploads/2018/05/how-to-make-iced-coffee-31-735x1015.jpg" },


                new Meal{Caterer=caterers[0], Name="Bruschetta", MealType=MealType.Appetizer, Description="Double Tomato Bruschetta", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.cookingclassy.com/wp-content/uploads/2019/07/bruschetta-2.jpg" },
                new Meal{Caterer=caterers[0], Name="Coconut Shrimp", MealType=MealType.Appetizer, Description="Dipped in coconut beer batter", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://cafedelites.com/wp-content/uploads/2019/12/Coconut-Shrimp-2-500x500.jpg" },


                new Meal{Caterer=caterers[0], Name="Ice Cream", MealType=MealType.Dessert, Description="A delicious frozen treat", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.simplyrecipes.com/wp-content/uploads/2006/06/French-Vanilla-IceCream-LEAD-1.jpg" },
                new Meal{Caterer=caterers[0], Name="Cake", MealType=MealType.Dessert, Description="Yummy birthday cake", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.cookingclassy.com/wp-content/uploads/2019/07/birthday-cake-4.jpg" },


                new Meal{Caterer=caterers[0], Name="Salad", MealType=MealType.Greens, Description="It has iceberg lettuce", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://food.fnr.sndimg.com/content/dam/images/food/fullset/2004/1/23/1/ss1d27_mixed_green_salad.jpg.rend.hgtvcom.826.620.suffix/1386276604828.jpeg" },
                new Meal{Caterer=caterers[0], Name="Green Beans", MealType=MealType.Greens, Description="Aren't we just two peas in pod", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.simplyrecipes.com/wp-content/uploads/2009/11/green-beans-almonds-thyme-1800-2.jpg" },

                new Meal{Caterer=caterers[0], Name="Cookie", MealType=MealType.Pastry, Description="A chocolate chip cookie", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://images-gmi-pmc.edge-generalmills.com/087d17eb-500e-4b26-abd1-4f9ffa96a2c6.jpg" },
                new Meal{Caterer=caterers[0], Name="Muffin", MealType=MealType.Pastry, Description="A nice muffin to have", 
                    ValidUntil=new DateTime(2020, 5, 25), ImageUrl ="https://www.handletheheat.com/wp-content/uploads/2009/09/Chocolate-Chip-Muffins-SQUARE.jpg" },
            };

            meals.ForEach(s => context.Meals.Add(s));
            context.SaveChanges();

            var mealConfiguration = new List<MealConfiguration>
            {
                new MealConfiguration{Meal=meals[0], Ingredients="buns,hamburger,ketchup", Price=5.99m},
                new MealConfiguration{Meal=meals[0], Ingredients="buns,hamburger,ketchup,pickels", Price=5.99m},
                new MealConfiguration{Meal=meals[1], Ingredients="buns,hamburger,ketchup", Price=3.50m},
                new MealConfiguration{Meal=meals[1], Ingredients="buns,hamburger,ketchup,pickels", Price=3.99m},
                new MealConfiguration{Meal=meals[2], Ingredients="chicken,sweet&sour", Price=5.99m},
                new MealConfiguration{Meal=meals[2], Ingredients="chicken,barbeque", Price=5.99m},
                new MealConfiguration{Meal=meals[3], Ingredients="dough,sauce,cheese,pepperoni", Price=2.99m},
                new MealConfiguration{Meal=meals[3], Ingredients="dough,sauce,pepperoni", Price=2.50m},
                new MealConfiguration{Meal=meals[4], Ingredients="dough,sauce,pepperoni", Price=4.99m},
                new MealConfiguration{Meal=meals[5], Ingredients="meat,loaf", Price=2.50m},
                new MealConfiguration{Meal=meals[6], Ingredients="milk,vanilla,cream", Price=4.50m},
                new MealConfiguration{Meal=meals[7], Ingredients="ice,coffee", Price=2.99m},
                new MealConfiguration{Meal=meals[8], Ingredients="bread,tomato", Price=3.99m},
                new MealConfiguration{Meal=meals[9], Ingredients="shrimp,breaded", Price=3.99m},
                new MealConfiguration{Meal=meals[10], Ingredients="milk,cream", Price=4.99m},
                new MealConfiguration{Meal=meals[11], Ingredients="sugar,icing", Price=3.99m},
                new MealConfiguration{Meal=meals[12], Ingredients="lettuce,tomato,pepper", Price=6.50m},
                new MealConfiguration{Meal=meals[13], Ingredients="beans", Price=1.99m},
                new MealConfiguration{Meal=meals[14], Ingredients="dough,chocolatechips", Price=3.50m},
                new MealConfiguration{Meal=meals[15], Ingredients="choclate", Price=2.99m},
            };

            mealConfiguration.ForEach(s => context.MealConfigurations.Add(s));
            context.SaveChanges();


            var orders = new List<Order>
            {
                new Order{Employee=employees[0], OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete },
                new Order{Employee=employees[1], OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[2], OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Account, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[3], OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[4], OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[5], OrderDate=new DateTime(2020, 2, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 2, 28), PaidStatus=PaidStatus.Unpaid, OrderStatus=OrderStatus.Complete},

                new Order{Employee=employees[6], OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 3, 28), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[7], OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 3, 27), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[8], OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 3, 28), PaidStatus=PaidStatus.Account, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[0], OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 4, 1), PaidStatus=PaidStatus.Cash, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[1], OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 4, 2), PaidStatus=PaidStatus.Credit, OrderStatus=OrderStatus.Complete},
                new Order{Employee=employees[2], OrderDate=new DateTime(2020, 3, 25), ModifiedDate=new DateTime(2020, 2, 25), ForDate=new DateTime(2020, 4, 5), PaidStatus=PaidStatus.Unpaid, OrderStatus=OrderStatus.Complete},
            };

            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();

            var orderItems = new List<OrderItem>
            {
                new OrderItem{ OrderId = 1, MealConfigurationId=12, Quantity=1 },
                new OrderItem{ OrderId = 2, MealConfigurationId=11, Quantity=5 },
                new OrderItem{ OrderId = 3, MealConfigurationId=10, Quantity=1 },
                new OrderItem{ OrderId = 4, MealConfigurationId=9, Quantity=1 },
                new OrderItem{ OrderId = 5, MealConfigurationId=8, Quantity=5 },
                new OrderItem{ OrderId = 6, MealConfigurationId=7, Quantity=1 },

                new OrderItem{ OrderId = 7 , MealConfigurationId=6, Quantity=3 },
                new OrderItem{ OrderId = 8, MealConfigurationId=5, Quantity=1 },
                new OrderItem{ OrderId = 9, MealConfigurationId=4, Quantity=1 },
                new OrderItem{ OrderId = 10, MealConfigurationId=3, Quantity=4 },
                new OrderItem{ OrderId = 11, MealConfigurationId=2, Quantity=1 },
                new OrderItem{ OrderId = 12, MealConfigurationId=1, Quantity=2 },

                new OrderItem{ OrderId = 1, MealConfigurationId=2, Quantity=1 },
                new OrderItem{ OrderId = 2, MealConfigurationId=1, Quantity=5 },
                new OrderItem{ OrderId = 3, MealConfigurationId=1, Quantity=1 },
                new OrderItem{ OrderId = 4, MealConfigurationId=4, Quantity=1 },
                new OrderItem{ OrderId = 5, MealConfigurationId=2, Quantity=5 },
                new OrderItem{ OrderId = 6, MealConfigurationId=1, Quantity=1 },
            };

            orderItems.ForEach(s => context.OrderItems.Add(s));
            context.SaveChanges();

            var cafeteriaFoods = new List<CafeteriaFood>
            {
                new CafeteriaFood{ CafeteriaAddressId = 1, MealType=MealType.Dessert, Name="cake", Price=3.99m },
                new CafeteriaFood{ CafeteriaAddressId = 2, MealType=MealType.Dessert, Name="chocolate", Price=2.99m },
                new CafeteriaFood{ CafeteriaAddressId = 3, MealType=MealType.Beverage, Name="coffee", Price=1.99m },

            };

            cafeteriaFoods.ForEach(s => context.CafeteriaFoods.Add(s));
            context.SaveChanges();
        }

    public static async Task AddToUsersRoles(ApplicationUser user, CafeteriaContext context, int i)
        {
            var userStore = new Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<ApplicationUser>(context);
            switch (i)
            {
                case 0:
                    await userStore.AddToRoleAsync(user, "Caterer");
                    break;
                case 1:
                    await userStore.AddToRoleAsync(user, "Employee");
                    break;
                case 2:
                    await userStore.AddToRoleAsync(user, "Organizer");
                    break;
                case 3:
                    await userStore.AddToRoleAsync(user, "Cashier");
                    break;
                default:
                    break;
            }
            await context.SaveChangesAsync();
        }

        internal static void Initialize(ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}