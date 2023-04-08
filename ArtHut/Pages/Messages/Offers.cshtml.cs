using ArtHut.Business.Services;
using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtHut.Pages.Messages
{
	[Authorize]
	public class OffersModel : PageModel
    {
        private readonly IProductService _productService;
		private readonly IPhotosService _photosService;
		private readonly IOrderService _orderService;
		private readonly IAddressesService _addressesService;
		private readonly ICountriesService _countriesService;
		private readonly UserManager<User> _userManager;

        public OffersModel(UserManager<User> userManager, IProductService productService, IPhotosService photosService, IOrderService orderService, IAddressesService addressesService, ICountriesService countriesService)
        {
            _userManager = userManager;
			_productService = productService;
			_photosService = photosService;
			_orderService = orderService;
			_addressesService = addressesService;
			_countriesService = countriesService;
		}
		[BindProperty]
		public List<Product?> SoldProducts { get; set; }
		public async Task<IActionResult> OnGet()
        {
           SoldProducts = await _productService.GetSoldProductsOfUser(_userManager.GetUserId(User));
            return Page();
        }
		public byte[] GetProductMainImg(int productId)
		{
			return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
		}
		public Address GetBuyerAddress(int productId)
		{
			var product= _productService.FindProductAsync(productId).Result;
			var address = _addressesService.FindAsync(_orderService.FindOrderAsync(product.IsSold).Result.AddressId).Result;
			return address;
		}
		public Data.Models.Order GetProductsOrder(int productId)
		{
			var product = _productService.FindProductAsync(productId).Result;
			var order = _orderService.FindOrderAsync(product.IsSold).Result;
			return order;
		}
		public string GetCountryName(int id)
		{
			return _countriesService.GetByIdAsync(id).Result.Name;
		}
	}
}
