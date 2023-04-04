using ArtHut.Business.Services;
using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace ArtHut.Pages.Order
{
	[Authorize]
	public class ReviewModel : PageModel
	{
		private readonly ICartsService _cartsService;
		private readonly IProductService _productService;
		private readonly IPhotosService _photosService;
		private readonly IOrderService _orderService;
		private readonly IAddressesService _addressesService;
		private readonly IPaymentsService _paymentsService;
		private readonly ICountriesService _countriesService;
		private readonly UserManager<User> _userManager;

		public ReviewModel(ICartsService cartsService, IProductService productService, IPhotosService photosService, UserManager<User> userManager, IOrderService orderService, IAddressesService addressesService, IPaymentsService paymentsService, ICountriesService countriesService)
		{
			_cartsService = cartsService;
			_userManager = userManager;
			_productService = productService;
			_photosService = photosService;
			_orderService=orderService;
			_addressesService=addressesService;
			_paymentsService=paymentsService;
			_addressesService = addressesService;
			_countriesService=countriesService;
			_countriesService= countriesService;
		}
		[BindProperty]
		public List<CartItem> Cart { get; set; }
		[BindProperty]
		public List<Product?> CartItems { get; set; }
		[BindProperty]
		public Data.Models.Order Order { get; set; }
		[BindProperty]
		public Address Address { get; set; }
		[BindProperty]
		public Payment Payment { get; set; }

		public async Task<IActionResult> OnGet(int id)
		{
			Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
			CartItems =  new List<Product?>();
			ViewData["ArtTotal"] = 0;

			if (Cart.Count > 0)
			{
				foreach (var item in Cart)
				{
					CartItems.Add(_productService.FindProductAsync(item.ProductId).Result);
				}
				CartItems = CartItems.OrderBy(x => x.UserId).ToList(); ;//Products.OrderBy(x=> x.UserId).ToList();
				ViewData["ArtTotal"] = CartItems.Sum(x => x.Price);
			}

			Order= _orderService.FindOrderAsync(id).Result;
			Address = _addressesService.FindAsync(Order.AddressId).Result;
			Payment = _paymentsService.FindAsync(Order.PaymentId).Result;

			return Page();
		}
		public byte[] GetProductMainImg(int productId)
		{
			return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
		}
		public async Task<IActionResult> OnPost(int id)
		{
			Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
			CartItems =  new List<Product?>();

			foreach (var item in Cart)
			{
				CartItems.Add(_productService.FindProductAsync(item.ProductId).Result);
			}

			if (CartItems.FindAll(x => x.IsSold!=null).Any())
			{
				var product = CartItems.FirstOrDefault(x => x.IsSold!=null);
				var cartItem = Cart.Where(x => x.ProductId == product.Id).First();
				await _cartsService.RemoveCartItemAsync(cartItem);
				return RedirectToPage("Error", new { product = product.Id });
			}
			else
			{
				Order= _orderService.FindOrderAsync(id).Result;
				Order.CreatedAt=DateTime.Now;
				await _orderService.UpdateAsync(Order);

				foreach (var item in CartItems)
				{
					item.Order = Order;
					await _productService.UpdateAsync(item);
				}
				await _cartsService.RemoveRangeCartItemAsync(Cart);
				return RedirectToPage("Success");
			}
			
		}

		public string GetCountryName(int id)
		{
			return _countriesService.GetByIdAsync(id).Result.Name;
		}

	}
}
