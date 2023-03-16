using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtHut.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartsService _cartsService;
        private readonly IProductService _productService;
        private readonly IPhotosService _photosService;
        private readonly UserManager<User> _userManager;

        public CartModel(ICartsService cartsService, IProductService productService, IPhotosService photosService, UserManager<User> userManager)
        {
            _cartsService = cartsService;
            _userManager = userManager;
            _productService = productService;
            _photosService = photosService;
        }
        [BindProperty]
        public List<CartItem> Cart { get; set; }
        [BindProperty]
        public List<Product?> CartItems { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
            CartItems =  new List<Product?>();
            if (Cart.Count > 0)
            {
               
                foreach (var item in Cart)
                {
                    CartItems.Add(_productService.FindProductAsync(item.ProductId).Result);
                }
                //Products.OrderBy(x=> x.UserId).ToList();
                var ProductsWhitSameArtist = CartItems.GroupBy(x => x.UserId);
            }

            return Page();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
            await _cartsService.RemoveCartItemAsync(Cart.Where(x=>x.ProductId==id).FirstOrDefault());
            return RedirectToPage("Cart");
        }
        public byte[] GetProductMainImg(int productId)
        {
            return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
        }
    }
}
