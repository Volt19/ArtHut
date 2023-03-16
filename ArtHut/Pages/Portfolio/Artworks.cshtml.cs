using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages.Portfolio
{
    public class ArtworksModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IPhotosService _photosService;
        private readonly ICategoriesService _categoriesService;
        private readonly IMessagesService _messagesService;
        private readonly UserManager<User> _userManager;

        public ArtworksModel(IProductService productService, UserManager<User> userManager, IPhotosService photosService, ICategoriesService categoriesService, IMessagesService messagesService)
        {
            _productService = productService;
            _userManager = userManager;
            _photosService = photosService;
            _categoriesService = categoriesService;
            _messagesService = messagesService;
        }
        [BindProperty]
        public List<Product?> Products { get; set; }
        [BindProperty]
        public List<Product?> ProductsCol1 { get; set; }
        [BindProperty]
        public List<Product?> ProductsCol2 { get; set; }
        [BindProperty]
        public List<Product?> ProductsCol3 { get; set; }
        [BindProperty]
        public List<Category?> Categories { get; set; }
        [BindProperty]
        public  string Artist { get; set; }
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
        public async Task<IActionResult> OnGet()
        {
            ViewData["User"]= _userManager.GetUserId(User);
            Products=_productService.GetUsersProducts(_userManager.GetUserId(User)).Result;
            ProductsCol1 = new List<Product?>();
            ProductsCol2 = new List<Product?>();
            ProductsCol3 = new List<Product?>();
            for (int i = 0, col = 0; i< Products?.Count; i++)
            {
                col++;
                if (col==1)
                {
                    ProductsCol1.Add(Products?[i]);
                }
                if (col==2)
                {
                    ProductsCol2.Add(Products?[i]);
                }
                if (col==3)
                {
                    ProductsCol3.Add(Products?[i]);
                }

                if (col == 3) { col =0; }
            }

            Categories = _categoriesService.GetAll().Result;

            return Page();
        }
        public async Task<IActionResult> OnGetArtist(string artist)
        {
			Artist = artist;
            ViewData["User"]=artist;
            Products=_productService.GetUsersProducts(artist).Result;
            ProductsCol1 = new List<Product?>();
            ProductsCol2 = new List<Product?>();
            ProductsCol3 = new List<Product?>();
            for (int i = 0, col = 0; i< Products?.Count; i++)
            {
                col++;
                if (col==1)
                {
                    ProductsCol1.Add(Products?[i]);
                }
                if (col==2)
                {
                    ProductsCol2.Add(Products?[i]);
                }
                if (col==3)
                {
                    ProductsCol3.Add(Products?[i]);
                }

                if (col == 3) { col =0; }
            }

            Categories = _categoriesService.GetAll().Result;

            return Page();
        }

		public async Task<IActionResult> OnPostSend()
		{

            var newMessage = await _messagesService.SendMessageAsync(new Message(MessageInput.Subject, MessageInput.Message, _userManager.GetUserId(User), Artist));
            return RedirectToPage("Artworks", new { artist = Artist }); 
		}

		public byte[] GetProductMainImg(int productId)
        {
            return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
        }
    }
}
