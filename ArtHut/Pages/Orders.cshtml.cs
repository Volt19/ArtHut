using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ArtHut.Pages
{
	[Authorize]
	public class OrdersModel : PageModel
    {
		private readonly ICartsService _cartsService;
		private readonly IProductService _productService;
		private readonly IPhotosService _photosService;
		private readonly IOrderService _orderService;
		private readonly UserManager<User> _userManager;


		public OrdersModel(ICartsService cartsService, IProductService productService, IPhotosService photosService, IOrderService orderService, UserManager<User> userManager)
		{
			_cartsService = cartsService;
			_userManager = userManager;
			_productService = productService;
			_photosService = photosService;
			_orderService = orderService;
		}
		[BindProperty]
		public List<Data.Models.Order> Orders { get; set; }
		public async Task<IActionResult> OnGet()
		{
			DateTime emptyDT = DateTime.ParseExact("01/01/0001 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
			Orders = _orderService.GetUsersOrdersAsync(_userManager.GetUserId(User)).Result.Where(x=>x.CreatedAt!=emptyDT).ToList();
			return Page();
		}
		public async Task<IActionResult> OnPostConfirm(int id)
		{
			return Page();
		}
		public async Task<IActionResult> OnPostReject(int id)
		{
			return Page();
		}
		public byte[] GetProductMainImg(int productId)
		{
			return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
		}
	}
}
