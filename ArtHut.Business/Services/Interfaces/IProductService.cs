using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product?> FindProductAsync(params object[] keyValues);
        Task<List<Product?>> GetAll();
        Task<List<Product>> GetUsersProducts(string userId);
        Task UpdateAsync(Product product);
        Task<List<Product>> GetOrdersProducts(int orderId);
        Task<List<Product>> GetSoldProductsOfUser(string userId);
	}
}
