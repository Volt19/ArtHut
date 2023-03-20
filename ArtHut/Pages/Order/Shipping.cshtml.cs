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
        private readonly IAddressesService _addressesService;

        public ShippingModel(UserManager<User> userManager, IAddressesService addressesService)
        {
            _addressesService = addressesService;
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
            [Required]
            [Display(Name = "Country")]
            public int CountryId { get; set; }
            [Required]
            [Display(Name = "District")]
            public string District { get; set; }
            [Required]
            [Display(Name = "City")]
            public string City { get; set; }
            [Required]
            [Display(Name = "PostalCode")]
            public string PostalCode { get; set; }
            [Required]
            [Display(Name = "StreetAddress")]
            public string StreetAddress { get; set; }
            //[Display(Name = "Comment")]
            //public string Comment { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var e = Input.PhoneNumber;
                var ee= Input.Email;
                var eee= Input.LastName;
                var eeee= Input.LastName;
                await _addressesService.AddAddressAsync(new Address(Input.CountryId, Input.District, Input.City, Input.PostalCode, Input.StreetAddress, _userManager.GetUserId(User)));

            }

            return Page();
        }
    }
}
