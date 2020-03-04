using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int EmployeeID { get; set; }
        public int MealID { get; set; }

        public Employee Employee { get; set; }
        public Meal Meal { get; set; }

    }
}
