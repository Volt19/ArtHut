using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace ArtHut.Pages.ArtPost
{
    public class SecondStepcshtmlModel : PageModel
    {
        [BindProperty]
        public static Product NewProduct { get; set; }
        private readonly IProductService _productService;
        private readonly IPhotosService _photosService;
        private readonly UserManager<User> _userManager;

        public SecondStepcshtmlModel(IProductService productService, UserManager<User> userManager, IPhotosService photosService)
        {
            _productService = productService;
            _userManager = userManager;
            _photosService = photosService;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        
        public class InputModel
        {
            public IFormFile Picture
            {
                get;
                set;
            }
        }
        public async Task<IActionResult> OnGet(int productId)
        {
            NewProduct =_productService.FindProductAsync(productId).Result;
            return Page();
        }
        public async Task<IActionResult> OnGetDev(int productId = 1)
        {
            NewProduct =_productService.FindProductAsync(productId).Result;
            //ImageConverter ic = new ImageConverter();
            //Image img = (Image)ic.ConvertFrom(bytes);
            return Page();
        }
		public async Task<IActionResult> OnPostBack()
		{
			return RedirectToPage("FirstStep", new { product = NewProduct });
		}
		public async Task<IActionResult> OnPostAdd()
        {
            byte[] bytes = null;
            if (Input.Picture != null)
            {
                using (Stream fs = Input.Picture.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes= br.ReadBytes((Int32)fs.Length);
                    }
                }
                //Input.PictureName=Convert.ToBase64String(bytes, 0, bytes.Length);

                Photo NewPhoto = new Photo(bytes, Input.Picture.ContentType, NewProduct.Id, _userManager.GetUserAsync(HttpContext.User)?.Result.Id);
                await _photosService.AddPhotoAsync(NewPhoto);
                return Page();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostNext()
        {
            return Page();
        }

    }
}
