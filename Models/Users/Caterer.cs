using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public class Caterer : ApplicationUser
    {
        public virtual ICollection<Meal> Meal { get; set; }
    }
}
