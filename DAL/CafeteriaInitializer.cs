using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CafeteriaOnline.Website.Models;

namespace CafeteriaOnline.Website.DAL
{
    public class CafeteriaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CafeteriaContext>
    {
        protected override void Seed(CafeteriaContext context)
        {    
            var employees = new List<Employee>
            {
            new Employee{EmployeeNumber=1, FirstName="Logan", LastName="James"},
            new Employee{EmployeeNumber=2, FirstName="Blazor", LastName="Raze"},
            new Employee{EmployeeNumber=2, FirstName="Mancy", LastName="Cruze"},
            new Employee{EmployeeNumber=2, FirstName="Janet", LastName="Planet"},

            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();


            var ingredients = new List<Ingredient>
            {
            new Ingredient{Name="Chicken Thighs", ActiveStatus=true},
            new Ingredient{Name="Chicken Breasts", ActiveStatus=true},
            new Ingredient{Name="Hamburger", ActiveStatus=true},
            new Ingredient{Name="Buns", ActiveStatus=true},
            new Ingredient{Name="Cheese Slice", ActiveStatus=true},
            new Ingredient{Name="Lettuce", ActiveStatus=true},
            new Ingredient{Name="Tomato", ActiveStatus=true},
            };

            ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();


            var meals = new List<Meal>
            {
            new Meal{Name="Cheese Burger", MealType=MealType.Entrée, Price=9, ActiveStatus=true, ImageUrl="https://www.mcdonalds.com/content/dam/usa/nfl/nutrition/items/regular/desktop/t-mcdonalds-qpc-deluxe-burger.jpg" }
            };

            meals.ForEach(s => context.Meals.Add(s));
            context.SaveChanges();


            var baseMealIngredients = new List<BaseMealIngredient>
            {
                new BaseMealIngredient{MealID=1, IngredientID=3},
                new BaseMealIngredient{MealID=1, IngredientID=4},
                new BaseMealIngredient{MealID=1, IngredientID=5},
            };
            baseMealIngredients.ForEach(s => context.BaseMealIngredients.Add(s));
            context.SaveChanges();

            var configMeal = new List<ConfigMealIngredient>
            { 
                new ConfigMealIngredient{MealID=1, IngredientID=6},
                new ConfigMealIngredient{MealID=1, IngredientID=7},
            };

            configMeal.ForEach(s => context.ConfigMealIngredients.Add(s));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{EmployeeID=1, MealID=1},
            };

            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
        }
    }
}