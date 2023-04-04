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
	public class ShippingModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IAddressesService _addressesService;
		private readonly IOrderService _orderService;
		private readonly ICartsService _cartsService;
		private readonly IProductService _productService;

		public ShippingModel(UserManager<User> userManager, IAddressesService addressesService, IOrderService orderService, ICartsService cartsService, IProductService productService)
        {
            _addressesService = addressesService;
            _userManager = userManager;
            _orderService = orderService;
            _cartsService = cartsService;
            _productService = productService;

        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
			[Required]
			[Display(Name = "First Name")]
            public string FirstName { get; set; }
			[Required]
			[Display(Name = "Last Name")]
            public string LastName { get; set; }
			[Required]
			[Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
			[Required]
			[DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [Display(Name = "Country")]
            public int CountryId { get; set; }
            [Required]
            [Display(Name = "District")]
            public string District { get; set; }
            [Required]
            [Display(Name = "City")]
            public string City { get; set; }
            [Required]
            [Display(Name = "PostalCode")]
            public string PostalCode { get; set; }
            [Required]
            [Display(Name = "StreetAddress")]
            public string StreetAddress { get; set; }
            //[Display(Name = "Comment")]
            //public string Comment { get; set; }
        }
        private async Task LoadAsync(User user)
        {
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Email= email
            };
        }
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);

			var Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
			decimal sum = 0m;
			if (Cart.Count > 0)
			{
				ViewData["ArtTotal"] = (decimal)Cart.Sum(item => _productService.FindProductAsync(item.ProductId).Result.Price);
			}
			return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
				var Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
                decimal sum = 0m;
				if (Cart.Count > 0)
                {
					sum = (decimal)Cart.Sum(item => _productService.FindProductAsync(item.ProductId).Result.Price);
				}
				 
				var address = await _addressesService.AddAddressAsync(new Address(Input.CountryId, Input.District, Input.City, Input.PostalCode, Input.StreetAddress));  
                var order = await _orderService.AddOrderAsync(new Data.Models.Order(address.Id, null, null, sum, null, _userManager.GetUserId(User), Input.FirstName, Input.LastName, Input.PhoneNumber, Input.Email));
				return RedirectToPage("PaymentDetails", new { id=order.Id});
			} 
			return Page();
		}
    }
}
