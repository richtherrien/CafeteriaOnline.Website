using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Cashier : ApplicationUser
    {
        public int CashierID { get; set; }
        public ICollection<CafeteriaAddress> CafeteriaAddress { get; set; }
    }
}
