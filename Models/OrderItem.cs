namespace CafeteriaOnline.Website.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int MealConfigurationId { get; set; }
        public virtual MealConfiguration MealConfiguration { get; set; }
        public int Quantity { get; set; }
    }
}
