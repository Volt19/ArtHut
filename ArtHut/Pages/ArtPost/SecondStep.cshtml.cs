using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
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
            [Required]
            [DisplayName("Main Picture")]
            public IFormFile MainPicture { get; set; }
            public IFormFile? OtherPicture1 { get; set; }
            public IFormFile? OtherPicture2 { get; set; }
            public IFormFile? OtherPicture3 { get; set; }
            public IFormFile? OtherPicture4 { get; set; }
            public IFormFile? OtherPicture5 { get; set; }
            public IFormFile? OtherPicture6 { get; set; }
            public IFormFile? OtherPicture7 { get; set; }
            public IFormFile? OtherPicture8 { get; set; }
            public IFormFile? OtherPicture9 { get; set; }
            public IFormFile? OtherPicture10 { get; set; }
        }
        public async Task<IActionResult> OnGet(int productId)
        {
            NewProduct =_productService.FindProductAsync(productId).Result;
            return Page();
        }
        //public async Task<IActionResult> OnGetDev(int productId )
        //{
        //    NewProduct =_productService.FindProductAsync(productId).Result;
        //    //ImageConverter ic = new ImageConverter();
        //    //Image img = (Image)ic.ConvertFrom(bytes);
        //    return Page();
        //}
        public async Task<IActionResult> OnPostBack()
        {
            return RedirectToPage("FirstStep", new { product = NewProduct });
        }
        public async Task<IActionResult> OnPostAdd()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostNext()
        {
            if (ModelState.IsValid)
            {
                List<IFormFile> Pictures = new List<IFormFile>();
                Pictures.Add(Input.MainPicture);
                Pictures.Add(Input.OtherPicture1);
                Pictures.Add(Input.OtherPicture2);
                Pictures.Add(Input.OtherPicture3);
                Pictures.Add(Input.OtherPicture4);
                Pictures.Add(Input.OtherPicture5);
                Pictures.Add(Input.OtherPicture6);
                Pictures.Add(Input.OtherPicture7);
                Pictures.Add(Input.OtherPicture8);
                Pictures.Add(Input.OtherPicture9);
                Pictures.Add(Input.OtherPicture10);

                foreach (var picture in Pictures)
                {
                    byte[] bytes = null;
                    if (picture!=null)
                    {
                        using (Stream fs = picture.OpenReadStream())
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                bytes= br.ReadBytes((Int32)fs.Length);
                            }
                        }
                        if (picture.Name == "Input.MainPicture" )
                        {
                            await _photosService.AddPhotoAsync(new Photo(bytes, picture.ContentType, NewProduct.Id, true));
                        }
                        else
                        {
                            await _photosService.AddPhotoAsync(new Photo(bytes, picture.ContentType, NewProduct.Id, false));
                        }
                        
                    }
                }
                Product thisProduct = _productService.FindProductAsync(NewProduct.Id).Result;
                thisProduct.CreatedAt=DateTime.Now;
                await _productService.UpdateAsync(thisProduct);
            }

            //Photo test = _photosService.FindProductsMainPhotoAsync(NewProduct.Id).Result;
            //ImageBytes = test.Bytes;
            //ImageConverter ic = new ImageConverter();
            //immg = (Image)ic.ConvertFrom(test.Bytes);

            return Page();
        }

    }
}
