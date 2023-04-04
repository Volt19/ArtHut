using ArtHut.Business.Services;
using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IPhotosService _photosService;
        private readonly ICategoriesService _categoriesService;
		private readonly ICartsService _cartsService;
		private readonly IMessagesService _messagesService;
		private readonly UserManager<User> _userManager;

        public ProductModel(IProductService productService, UserManager<User> userManager, IPhotosService photosService,
			ICategoriesService categoriesService,ICartsService cartsService, IMessagesService messagesService)
        {
            _productService = productService;
            _userManager = userManager;
            _photosService = photosService;
            _categoriesService = categoriesService;
			_cartsService = cartsService;
			_messagesService = messagesService;
		}

        [BindProperty]
        public List<Photo?> ProductPhotos { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public Category ProductCategory { get; set; }
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
		public async Task<IActionResult> OnGet(int id)
        {
            ProductPhotos = _photosService.GetProductsPhotosAsync(id).Result;
            Product = _productService.FindProductAsync(id).Result;
            ProductCategory = _categoriesService.GetCategoryAsync((int)Product.CategoryId).Result;


            return Page();
        }
		public async Task<IActionResult> OnPostSend(int id)
		{
			var Product = _productService.FindProductAsync(id).Result;
			var newMessage = await _messagesService.SendMessageAsync(new Message(MessageInput.Subject, MessageInput.Message, _userManager.GetUserId(User), Product.UserId));
			return RedirectToPage("Product", new { id = id });
		}
		public async Task<IActionResult> OnPostAddToCart(int id)
		{
			if (!HttpContext.User.Identity.IsAuthenticated)
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });
			}

			var Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
			if (!Cart.Where(x => x.ProductId==id).Any())
			{
				await _cartsService.AddCartItemAsync(new CartItem(id, _userManager.GetUserId(User), true));
			}

			return RedirectToPage("Product", new { id=id});
		}
	}
}
