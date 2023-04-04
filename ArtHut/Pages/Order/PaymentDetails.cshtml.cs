using ArtHut.Business.Services;
using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Pages.Order
{
	[Authorize]
	public class PaymentDetailsModel : PageModel
    {
        private readonly UserManager<User> _userManager;
		private readonly IOrderService _orderService;
		private readonly IPaymentsService _paymentsService;
		private readonly ICartsService _cartsService;
		private readonly IProductService _productService;

		public PaymentDetailsModel(UserManager<User> userManager, IOrderService orderService, IPaymentsService paymentsService, ICartsService cartsService, IProductService productService)
        {
            _userManager = userManager;
			_orderService = orderService;
			_paymentsService = paymentsService;
			_cartsService = cartsService;
			_productService = productService;
        }
		[BindProperty]
		public List<CartItem> Cart { get; set; }
		[BindProperty]
		public List<Product?> CartItems { get; set; } 
		[BindProperty]
		public CreditCardInfo CreditCard { get; set; }
		[BindProperty]
		public bool OnDelivery { get; set; }
		public class CreditCardInfo
		{

			[Display(Name = "Cardholder Name")]
			public string CardholderName { get; set; }
			[Display(Name = "Card Number")]
			[DataType(DataType.CreditCard)]
			public string CardNumber { get; set; }
			[Display(Name = "Expiration Date")]
			public string ExpirationDate { get; set; }
			[Display(Name = "CVV")]
			public string CVV { get; set; }
		}
		public async Task<IActionResult> OnGet(int id)
		{
			var Cart = _cartsService.GetCartAsync(_userManager.GetUserId(User)).Result;
			decimal sum = 0m;
			if (Cart.Count > 0)
			{
				ViewData["ArtTotal"] = (decimal)Cart.Sum(item => _productService.FindProductAsync(item.ProductId).Result.Price);
			}
			return Page();
		}
		public async Task<IActionResult> OnPost(int id)
		{
			if (OnDelivery)
			{
				var order = _orderService.FindOrderAsync(id).Result;
				order.PaymentId = 1;
				await _orderService.UpdateAsync(order);
			}
			else
			{
				var order = _orderService.FindOrderAsync(id).Result;
				var payment = _paymentsService.AddPaymentAsync(new Payment(CreditCard.CardholderName, CreditCard.CardNumber, CreditCard.ExpirationDate, CreditCard.CVV)).Result;
				order.Payment = payment;
				await _orderService.UpdateAsync(order);
			}
			return RedirectToPage("Review", new { id = id});
		}

		
	}
}
