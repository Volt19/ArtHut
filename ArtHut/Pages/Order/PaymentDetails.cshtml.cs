using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages.Order
{
    public class PaymentDetailsModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public PaymentDetailsModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Display(Name = "Cartholder name")]
            [Required]
            public string CartholderName { get; set; }

            [DataType(DataType.CreditCard)]
            [Display(Name = "Card Details")]
            [Required]
            public string CardDetails { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }
    }
}
