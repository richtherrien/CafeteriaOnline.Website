using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Caterer : ApplicationUser
    {
        public int CatererID { get; set; }
        public ICollection<Meal> Meal { get; set; }
    }
}
