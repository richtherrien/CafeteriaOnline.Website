﻿using System;
using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public enum MealType 
    { 
        Appetizer, Beverage, Dessert, Entrée, Greens, Pastry
    }
    public class Meal
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public virtual MealType MealType { get; set; }
        public string Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<MealConfiguration> MealConfigurations { get; set; }
        public string CatererId { get; set; }
        public virtual Caterer Caterer { get; set; }

    }
}
