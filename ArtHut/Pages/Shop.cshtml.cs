using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArtHut.Data.Models;
using ArtHut.Business.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ArtHut.Pages
{
    public class ShopModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IPhotosService _photosService;
        private readonly ICategoriesService _categoriesService;
        private readonly ICartsService _cartsService;
        private readonly UserManager<User> _userManager;

        public ShopModel(IProductService productService, UserManager<User> userManager, IPhotosService photosService, ICategoriesService categoriesService, ICartsService cartsService)
        {
            _productService = productService;
            _userManager = userManager;
            _photosService = photosService;
            _categoriesService = categoriesService;
            _cartsService = cartsService;
        }
        [BindProperty]
        public List<Product?> Products { get; set; }
        [BindProperty]
        public List<Product?> ProductsCol1 { get; set ; }
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
        public async Task<IActionResult> OnGet(string category)
        {
            Category = category;
            if (category == null)
            {
                Products=_productService.GetAll().Result.Where(x => x.CreatedAt!=null).OrderByDescending(x=> x.Id).ToList();
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
                        CategoryId = 7 ;
                        break;

                }
                Products=_productService.GetAll().Result.Where(x => x.CreatedAt!=null && x.CategoryId == CategoryId).OrderByDescending(x => x.Id).ToList();
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
        public byte[] GetProductMainImg(int productId)
        {
            return _photosService.FindProductsMainPhotoAsync(productId).Result.Bytes;
        }

        public async Task<IActionResult> OnPostAddToCart(int productId)
        {
            var Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
            if(!Cart.Where(x => x.ProductId==productId).Any())
            {
                await _cartsService.AddCartItemAsync(new CartItem(productId, _userManager.GetUserId(User), true));
            }
            
            return RedirectToPage("Shop", new { category = Category});
        }
    }
}
