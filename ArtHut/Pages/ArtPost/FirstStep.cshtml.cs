using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArtHut.Data.Models;
using ArtHut.Business.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ArtHut.Pages.ArtPost
{
	[Authorize]
	public class ArtPostModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;

        public ArtPostModel(IProductService productService, UserManager<User> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }
        
        [BindProperty]
        public InputModel Input { get; set; }
        public bool IsUnique { get; set; }
        public class InputModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            [DataType(DataType.MultilineText)]
            public string? Description { get; set; }
            [Required]
            [Range(0, Int16.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
            [DisplayName("Price")]
            public int Price { get; set; }
            [DisplayName("Width")]
            public double SizeX { get; set; }
            [DisplayName("Length")]
            public double SizeY { get; set; }
            [DisplayName("Height")]
            public double SizeZ { get; set; }
            [Required]
            [Range(0, Int16.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
            public int? Qantity { get; set; }
            [Required]
            public int Category { get; set; }
        }
        public virtual async Task<IActionResult> OnGet()
        {
            return Page();
        }
        //public virtual async Task<IActionResult> OnGet(Product product)
        //{
        //    if (product.Name == null)
        //    {
        //        ViewData["IsUnique"]=true;
        //        return Page();
        //    }
        //    ViewData["Name"]=product.Name;
        //    ViewData["Description"]=product.Description;
        //    ViewData["Price"]=product.Price;
        //    var Sizes = product.Size.Split("x");
        //    ViewData["SizeX"]=Sizes[0];
        //    ViewData["SizeY"]=Sizes[1];
        //    ViewData["SizeZ"]=Sizes[2];
        //    ViewData["IsUnique"]=product.IsUnique;
        //    ViewData["Qantity"]=product.Qantity;
        //    return Page();
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Product NewProduct = await CreateProduct(new Product(Input.Name, Input.Description, Convert.ToDecimal(Input.Price), Convert.ToString(Input.SizeX+"x"+Input.SizeY+"x"+Input.SizeZ),
                    Input.Qantity, _userManager.GetUserAsync(HttpContext.User)?.Result, Input.Category));
                return RedirectToPage("SecondStep", new { productId = NewProduct.Id });
            }
            return Page();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productService.AddProductAsync(product);
        }
    }
}
