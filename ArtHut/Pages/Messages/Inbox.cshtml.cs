using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages.Messages
{
	[Authorize]
	public class InboxModel : PageModel
    {
        private readonly IMessagesService _messagesService;
        private readonly UserManager<User> _userManager;
        public InboxModel(UserManager<User> userManager, IMessagesService messagesService)
        {
            _userManager = userManager;
            _messagesService = messagesService;
        }
        public class InputMessageModel
        {
            [Required]
            public string Subject { get; set; }
            [Required]
            [DataType(DataType.MultilineText)]
            public string Message { get; set; }
        }
		[BindProperty]
		public List<Message?> Messages { get; set; }

		[BindProperty]
		public InputMessageModel MessageInput { get; set; }

		[BindProperty]
        public string MessageId { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Messages=_messagesService.ReceivedMessagesAsync(_userManager.GetUserId(User)).Result;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _messagesService.DeleteByIdAsync(id);
            return RedirectToPage("Inbox");
        }
        public async Task<IActionResult> OnPostSend()
        {

            var newMessage = await _messagesService.SendMessageAsync(new Message(MessageInput.Subject, MessageInput.Message, _userManager.GetUserId(User), MessageId));
            return RedirectToPage("Inbox");
        }
    }
}
