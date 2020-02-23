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
            var ingredients = new List<Ingredient>
            {
            new Ingredient{Name="Chicken Thighs", ActiveStatus=true},
            new Ingredient{Name="Hamburger", ActiveStatus=true},
            new Ingredient{Name="Buns", ActiveStatus=true},
            };

            ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();
        }
    }
}