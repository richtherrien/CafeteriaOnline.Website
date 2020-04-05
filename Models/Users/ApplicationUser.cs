using Microsoft.AspNetCore.Identity;

namespace CafeteriaOnline.Website.Models
{
    // email, username, etc. are stored in IdentityUser
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
