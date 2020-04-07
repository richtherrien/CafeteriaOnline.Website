using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaOnline.Website.Models
{
    public class Employee : ApplicationUser
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Balance { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public int CafeteriaAddressId { get; set; }
        public virtual CafeteriaAddress CafeteriaAddress { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
