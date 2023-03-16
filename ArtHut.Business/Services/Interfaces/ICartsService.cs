using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services.Interfaces
{
    public interface ICartsService
    {
        Task<CartItem> AddCartItemAsync(CartItem cartItem);
        Task<CartItem> GetCartItemAsync(int cartItemId);
        Task<List<CartItem>> GetCartAsync(string userId);
        Task RemoveCartItemAsync(CartItem cartItem);
    }
}
