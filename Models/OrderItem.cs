using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class OrderItem
    {
        internal object cart;

        public OrderItem(int mealConfigurationId, int quantity)
        {
            MealConfigurationId = mealConfigurationId;
            Quantity = quantity;
        }
        public OrderItem()
        {
        }
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int MealConfigurationId { get; set; }
        public virtual MealConfiguration MealConfiguration { get; set; }
        public int Quantity { get; set; }
    }
}
