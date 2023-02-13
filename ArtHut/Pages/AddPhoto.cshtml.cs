using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages
{
    public class AddPhotoModel : PageModel
    {
        public void OnGet()
        {
        }
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string PictureName { get; set; }
            [Required]
            public IFormFile Picture { get; set; }
        }
    }
}
