using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArtHut.Data.Models;
using ArtHut.Business.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace ArtHut.Pages
{
    public class ShopModel : PageModel
    {
        private readonly ITagsService _tagsService;
        public ShopModel(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }
        public async Task<IActionResult> OnGet()
        {
            //var newTag = ;
            await _tagsService.AddTagAsync(new Tag("Test"));
            return Page();
        }
    }
}
