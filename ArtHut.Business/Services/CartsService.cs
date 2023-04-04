using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using ArtHut.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services
{
    public class CartsService: ICartsService
    {
        private readonly ICartItemsRepository _cartItemsRepository;
        private readonly ICartsRepository _cartsRepository;

        public CartsService(ICartItemsRepository cartItemsRepository, ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
            _cartItemsRepository = cartItemsRepository;
        }
        public async Task<CartItem> AddCartItemAsync(CartItem cartItem) => await _cartItemsRepository.AddAsync(cartItem);
        public async Task<CartItem> GetCartItemAsync(int cartItemId) => await _cartItemsRepository.FindAsync(cartItemId);
        public async Task RemoveCartItemAsync(CartItem cartItem) => await _cartItemsRepository.DeleteAsync(cartItem);
		public async Task RemoveRangeCartItemAsync(List<CartItem> cartItems) => await _cartItemsRepository.DeleteRangeAsync(cartItems);
		public async Task<List<CartItem>> GetCartAsync(string userId) => await _cartItemsRepository.GetCartAsync(userId);
    }
}
