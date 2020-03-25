using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string CompanyCode { get; set; }
        public virtual ICollection<CafeteriaAddress> Addresses { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
