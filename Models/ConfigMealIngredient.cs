using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class ConfigMealIngredient
    {
        public int ID { get; set; }
        public int MealID { get; set; }
        public int IngredientID { get; set; }

        public Meal Meal { get; set; }

        public Ingredient Ingredient { get; set; }

    }
}
