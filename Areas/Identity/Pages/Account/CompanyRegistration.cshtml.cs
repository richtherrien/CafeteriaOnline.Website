using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CafeteriaOnline.Website.Data;
using CafeteriaOnline.Website.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace CafeteriaOnline.Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class CompanyRegistrationModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly CafeteriaContext _context;

        public CompanyRegistrationModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            CafeteriaContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        private static Random random = new Random();

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            //Company Info
            [Required]
            [Display(Name = "Company Name")]
            public string CompanyName { get; set; }

            [Required]
            [Display(Name = "Company Telephone")]
            public string Telephone { get; set; }

            [Required]
            [Display(Name = "Street Address")]
            public string StreetAddress { get; set; }

            [Required]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [Display(Name = "Province")]
            public string Province { get; set; }

            [Required]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Required]
            [DataType(DataType.PostalCode)]
            [Display(Name = "PostalCode")]
            public string PostalCode { get; set; }

            //Organizer Info
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public static string CompanyCodeGen(string companyName)
        {
            int length = 6;
            string shortCompanyName = companyName.Substring(0, 4).ToLower();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            string alphanumeric = new string (Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return (shortCompanyName + alphanumeric);
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                Company comp = new Company { Name = Input.CompanyName, Telephone = Input.Telephone, CompanyCode = CompanyCodeGen(Input.CompanyName) };
                _context.Companies.Add(comp);
                _context.SaveChanges();

                CafeteriaAddress address = new CafeteriaAddress { StreetAddress = Input.StreetAddress, City = Input.City, Province = Input.Province, Country = Input.Country, PostalCode = Input.PostalCode, Company = comp};
                _context.CafeteriaAddresses.Add(address);
                _context.SaveChanges();

                var user = new Organizer { UserName = Input.Email, Email = Input.Email, Company = comp, CafeteriaAddress = address, FirstName = Input.FirstName, LastName = Input.LastName};
                _context.Organizers.Add(user);

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Organizer");

                    _logger.LogInformation("User created a new account with password.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
