using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public class CafeteriaAddress
    {
        public int CafeteriaAddressId { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string CashierId { get; set; }
        public virtual Cashier Cashier { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public virtual ICollection<CafeteriaFood> CafeteriaFood { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
