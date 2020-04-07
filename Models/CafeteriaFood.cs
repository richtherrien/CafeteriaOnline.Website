using System.ComponentModel.DataAnnotations;

namespace CafeteriaOnline.Website.Models
{
    public class CafeteriaFood
    {
        public int CafeteriaFoodId { get; set; }
        public string Name { get; set; }
        public MealType MealType { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        public int CafeteriaAddressId { get; set; }
        public virtual CafeteriaAddress CafeteriaAddress { get; set; }
    }
}
