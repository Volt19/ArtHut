using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtHut.Pages.Messages
{
	[Authorize]
	public class SentModel : PageModel
    {
        private readonly IMessagesService _messagesService;
        private readonly UserManager<User> _userManager;
        public SentModel(UserManager<User> userManager, IMessagesService messagesService)
        {
            _userManager = userManager;
            _messagesService = messagesService;
        }
        [BindProperty]
        public List<Message?> Messages { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Messages=_messagesService.SendedMessagesAsync(_userManager.GetUserId(User)).Result;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _messagesService.DeleteByIdAsync(id);
            return RedirectToPage("Sent");
        }
    }
}
