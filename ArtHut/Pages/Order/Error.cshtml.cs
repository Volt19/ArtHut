using ArtHut.Business.Services;
using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtHut.Pages.Order
{
    public class ErrorModel : PageModel
    {
		private readonly IProductService _productService;
		private readonly IPhotosService _photosService;
		private readonly UserManager<User> _userManager;

		public ErrorModel( IProductService productService, UserManager<User> userManager, IPhotosService photosService)
		{ 
			_userManager = userManager;
			_productService = productService;
			_photosService = photosService;	
		}
		[BindProperty]
		public Product Product { get; set; }
		public void OnGet(int product)
        {
			Product = _productService.FindProductAsync(product).Result;
        }
		public byte[] GetProductMainImg(int productId)
		{
			return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
		}
	}
}
