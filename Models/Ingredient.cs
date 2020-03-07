using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool ActiveStatus { get; set; }

        public ICollection<Meal> Meal { get; set; }

    }
}
