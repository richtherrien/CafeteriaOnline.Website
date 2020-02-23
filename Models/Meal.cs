using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public enum MealType 
    { 
        Appetizer, Beverage, Dessert, Entrée, Greens, Pastry
    }
    public class Meal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public decimal Price { get; set; }
        public bool ActiveStatus { get; set; }
        public virtual ICollection<Ingredient> BaseIngredients { get; set; }
        public virtual ICollection<Ingredient> ConfigIngredients { get; set; }
        public string ImageUrl { get; set; }

    }
}
