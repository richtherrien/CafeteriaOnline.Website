using System.ComponentModel.DataAnnotations;

namespace CafeteriaOnline.Website.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int MealConfigurationId { get; set; }
        public virtual MealConfiguration MealConfiguration { get; set; }
        [Range(1, 25)]
        public int Quantity { get; set; }
        public decimal GetOrderItemPrice()
        {
            return MealConfiguration.Price * Quantity;
        }
    }
}
