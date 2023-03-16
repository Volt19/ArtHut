using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtHut.Pages.Messages
{
    public class OffersModel : PageModel
    {
        private readonly IMessagesService _messagesService;
        private readonly UserManager<User> _userManager;

        public OffersModel(UserManager<User> userManager, IMessagesService messagesService)
        {
            _userManager = userManager;
            _messagesService = messagesService;
        }

        public async Task<IActionResult> OnGet()
        {
           
            return Page();
        }
    }
}
