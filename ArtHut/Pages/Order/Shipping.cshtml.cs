using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages.Order
{
    public class ShippingModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public ShippingModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Display(Name = "Country")]
            public int CountryId { get; set; }
            [Display(Name = "District")]
            public string District { get; set; }
            [Display(Name = "City")]
            public string City { get; set; }
            [Display(Name = "PostalCode")]
            public string PostalCode { get; set; }
            [Display(Name = "StreetAddress")]
            public string StreetAddress { get; set; }
            [Display(Name = "Comment")]
            public string Comment { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }
    }
}
