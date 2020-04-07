using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaOnline.Website.Models
{
    public class MealConfiguration
    {
        public int MealConfigurationId { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public string Ingredients { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
