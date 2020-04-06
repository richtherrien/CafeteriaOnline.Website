using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public class Employee : ApplicationUser
    {
        public decimal Balance { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public int CafeteriaAddressId { get; set; }
        public virtual CafeteriaAddress CafeteriaAddress { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
