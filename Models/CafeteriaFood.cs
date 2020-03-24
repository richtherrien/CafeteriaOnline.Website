﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class CafeteriaFood
    {
        public int CafeteriaFoodID { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        public decimal Price { get; set; }
        public ICollection<CafeteriaAddress> CafeteriaAddress { get; set; }

    }
}
