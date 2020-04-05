using System.Collections.Generic;

namespace CafeteriaOnline.Website.Models
{
    public class Caterer : ApplicationUser
    {
        public ICollection<Meal> Meal { get; set; }
    }
}
