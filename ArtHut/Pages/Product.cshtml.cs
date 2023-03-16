using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtHut.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IPhotosService _photosService;
        private readonly ICategoriesService _categoriesService;
        private readonly UserManager<User> _userManager;

        public ProductModel(IProductService productService, UserManager<User> userManager, IPhotosService photosService, ICategoriesService categoriesService)
        {
            _productService = productService;
            _userManager = userManager;
            _photosService = photosService;
            _categoriesService = categoriesService;
        }

        [BindProperty]
        public List<Photo?> ProductPhotos { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public Category ProductCategory { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ProductPhotos = _photosService.GetProductsPhotosAsync(id).Result;
            Product = _productService.FindProductAsync(id).Result;
            ProductCategory = _categoriesService.GetCategoryAsync((int)Product.CategoryId).Result;


            return Page();
        }

        
    }
}
