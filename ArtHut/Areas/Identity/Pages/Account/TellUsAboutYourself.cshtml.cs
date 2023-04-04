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
using static Duende.IdentityServer.Models.IdentityResources;

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

            //[StringLength(100)]
            //[DataType(DataType.Text)]
            //[Display(Name = "Alias")]
            //public string? Alias { get; set; }

            [StringLength(100)]
            [DataType(DataType.Text)]
			[RegularExpression(@"^\S*$", ErrorMessage = "Spaces are not allowed.")]
			[Display(Name = "UserName")]
            public string UserName { get; set; }
        }
        [BindProperty]
        public string Email { get; set; }
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
		public async Task<IActionResult> OnPost()
        {
			if (ModelState.IsValid)
            {
				var user = _userManager.FindByEmailAsync(Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(Email))).Result;
				if (user != null)
				{
					user.UserName=Input.UserName;
                    user.NormalizedUserName = Input.UserName.ToUpper();
					var a=  _userManager.UpdateAsync((User)user).Result;
					user.FirstName=Input.FirstName;
					user.LastName=Input.LastName;
					var b = _userManager.UpdateAsync((User)user).Result;

					return RedirectToPage("../Shop", new { area = "" });
				}
				return Page();
			}

            //return RedirectToPage("PaymentDetails"); 
            return Page();
        }
    }
}
