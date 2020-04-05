using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public class Cashier : ApplicationUser
    {
        public ICollection<CafeteriaAddress> CafeteriaAddress { get; set; }
    }
}
