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
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }

    }
}
