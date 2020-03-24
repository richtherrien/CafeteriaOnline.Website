using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class CafeteriaAddress
    {
        public int CafeteriaAddressID { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public int CashierID { get; set; }
        public Cashier Cashier { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<CafeteriaFood> CafeteriaFood { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
