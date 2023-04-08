using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtHut.Pages.Order
{
	public class OrderDetailsModel : PageModel
	{
		private readonly IProductService _productService;
		private readonly IPhotosService _photosService;
		private readonly IOrderService _orderService;
		private readonly IAddressesService _addressesService;
		private readonly IPaymentsService _paymentsService;
		private readonly ICountriesService _countriesService;

		public OrderDetailsModel(IProductService productService, IPhotosService photosService, IOrderService orderService, IAddressesService addressesService, IPaymentsService paymentsService, ICountriesService countriesService)
		{
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
		public List<Product?> OrderedProducts { get; set; }
		[BindProperty]
		public Data.Models.Order Order { get; set; }
		[BindProperty]
		public Address Address { get; set; }
		[BindProperty]
		public Payment Payment { get; set; }

		public async Task<IActionResult> OnGet(int id)
		{
			OrderedProducts =  _productService.GetOrdersProducts(id).Result.OrderBy(x => x.UserId).ToList(); ;
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
			return Page();
		}

		public string GetCountryName(int id)
		{
			return _countriesService.GetByIdAsync(id).Result.Name;
		}
	}
}
