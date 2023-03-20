using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace ArtHut.Pages.Order
{
    public class ReviewModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public ReviewModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

        }
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }
    }
}
