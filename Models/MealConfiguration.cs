using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public class MealConfiguration
    {
        public int MealConfigurationId { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
