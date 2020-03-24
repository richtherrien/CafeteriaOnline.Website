using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaOnline.Website.Models
{
    public class Organizer : Employee
    {
        public int OrganizerID { get; set; }
        public Company HeadOf { get; set; }

    }
}
