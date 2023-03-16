using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages.Portfolio
{
    public class AboutMyWorkModel : PageModel
    {
        private readonly IMessagesService _messagesService;
        private readonly UserManager<User> _userManager;

        public AboutMyWorkModel(UserManager<User> userManager, IMessagesService messagesService)
        {
            _userManager = userManager;
            _messagesService = messagesService;
        }
        [BindProperty]
        public string Artist { get; set; }
        [BindProperty]
        public InputMessageModel MessageInput { get; set; }
        public class InputMessageModel
        {
            [Required]
            public string Subject { get; set; }
            [Required]
            [DataType(DataType.MultilineText)]
            public string Message { get; set; }
        }
        public async Task<IActionResult> OnGet(string artist)
        {
            ViewData["User"]=artist;
            Artist = artist;

            return Page();
        }
        public async Task<IActionResult> OnPostSend()
        {

            var newMessage = await _messagesService.SendMessageAsync(new Message(MessageInput.Subject, MessageInput.Message, _userManager.GetUserId(User), Artist));
            return RedirectToPage("Artworks", new { artist = Artist });
        }
    }
}
