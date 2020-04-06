using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public class Cashier : ApplicationUser
    {
        public virtual ICollection<CafeteriaAddress> CafeteriaAddress { get; set; }
    }
}
