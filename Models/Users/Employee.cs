using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Employee : Client
    {
        public int ID { get; set; }
        public int employeeNumber { get; set; }
    }
}
