using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Employee : ApplicationUser
    {
        public decimal Balance { get; set; }
        public ICollection<Order> Orders { get; set; }
        public virtual CafeteriaAddress CafeteriaAddress { get; set; }
        public virtual Company Company { get; set; }
    }
}
