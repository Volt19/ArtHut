using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetUsersProducts(string userId);
        Task<List<Product>> GetOrdersProducts(int orderId);
        Task<List<Product>> GetSoldProductsOfUser(string userId);

	}
}
