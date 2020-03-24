using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Employee : ApplicationUser
    {
        public int EmployeeID { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int CafeteriaAddressID { get; set; }
        public CafeteriaAddress CafeteriaAddresss { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
