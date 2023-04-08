using ArtHut.Business.Services;
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
		private readonly ICartsService _cartsService;
        private readonly UserManager<User> _userManager;

        public ArtworksModel(IProductService productService, UserManager<User> userManager, IPhotosService photosService, ICategoriesService categoriesService, IMessagesService messagesService, ICartsService cartsService)
        {
            _productService = productService;
            _userManager = userManager;
            _photosService = photosService;
            _categoriesService = categoriesService;
            _messagesService = messagesService;
			_cartsService = cartsService;
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
		public int? CategoryId { get; set; }
		[BindProperty]
		public string? Category { get; set; }
		[BindProperty]
        public  string Artist { get; set; }
		[BindProperty]
		public IFormFile ProfileImg { get; set; }
		[BindProperty]
		public IFormFile PortfolioImg { get; set; }
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
		public async Task<IActionResult> OnGetArtist(string artist, string category)
        {
			Artist = artist;
            ViewData["User"]=artist;
			Category = category;
			if (category == null)
			{
				Products=_productService.GetAll().Result.Where(x => x.CreatedAt!=null && x.UserId == artist).OrderByDescending(x => x.Id).ToList();
			}
			else
			{
				switch (category)
				{
					case "painting":
						CategoryId = 1;
						break;
					case "printmaking":
						CategoryId = 2;
						break;
					case "sculpture":
						CategoryId = 3;
						break;
					case "photography":
						CategoryId = 4;
						break;
					case "drawing":
						CategoryId = 5;
						break;
					case "digital art":
						CategoryId = 6;
						break;
					case "collage":
						CategoryId = 7;
						break;

				}
				Products=_productService.GetAll().Result.Where(x => x.CreatedAt!=null && x.CategoryId == CategoryId && x.UserId == artist).OrderByDescending(x => x.Id).ToList();
			}

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
			return RedirectToPage("Artworks", "Artist", new { artist = Artist, category = Category });
		}
		public async Task<IActionResult> OnPostProfileImgUpdate()
		{
			var user = await _userManager.GetUserAsync(User);
			byte[] bytes = null;
			if (ProfileImg!=null)
			{
				using (Stream fs = ProfileImg.OpenReadStream())
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						bytes= br.ReadBytes((Int32)fs.Length);
					}
				}
				user.ProfilePic = bytes;
				await _userManager.UpdateAsync(user);
			}
			
			return RedirectToPage("Artworks", "Artist", new { artist = Artist, category= Category });
		}
		public async Task<IActionResult> OnPostPortfolioImgUpdate()
		{
			var user = await _userManager.GetUserAsync(User);
			byte[] bytes = null;
			if (PortfolioImg!=null)
			{
				using (Stream fs = PortfolioImg.OpenReadStream())
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						bytes= br.ReadBytes((Int32)fs.Length);
					}
				}
				user.PortfolioPic = bytes;
				await _userManager.UpdateAsync(user);
			}

			return RedirectToPage("Artworks", "Artist", new { artist = Artist, category = Category });
		}

		public byte[] GetProductMainImg(int productId)
        {
            return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
        }

		public async Task<IActionResult> OnPostAddToCart(int productId)
		{
			if (!HttpContext.User.Identity.IsAuthenticated)
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			var Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
			if (!Cart.Where(x => x.ProductId==productId).Any())
			{
				await _cartsService.AddCartItemAsync(new CartItem(productId, _userManager.GetUserId(User), true));
			}

			return RedirectToPage("Artworks", "Artist", new { artist = Artist, category = Category });
		}
	}
}
