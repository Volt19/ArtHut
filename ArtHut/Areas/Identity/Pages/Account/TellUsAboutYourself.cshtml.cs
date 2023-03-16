using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace ArtHut.Areas.Identity.Pages.Account
{
    public class TellUsAboutYourselfModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public TellUsAboutYourselfModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100)]
            [DataType( DataType.Text)]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100)]
            [DataType(DataType.Text)]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [StringLength(100)]
            [DataType(DataType.Text)]
            [Display(Name = "Alias")]
            public string? Alias { get; set; }

            [StringLength(100)]
            [DataType(DataType.Text)]
            [Display(Name = "UserName")]
            public string UserName { get; set; }
        }
        private static string Email { get; set; }
        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }
            email = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(email));
            Email = email;
            var user = _userManager.FindByEmailAsync(email);
            return Page();
        }
    }
}
