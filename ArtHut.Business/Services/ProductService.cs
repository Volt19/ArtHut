using ArtHut.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Repositories.Interfaces;
using ArtHut.Data.Models;

namespace ArtHut.Business.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> AddProductAsync(Product product) =>await _productRepository.AddAsync(product);
        public async Task<Product?> FindProductAsync(params object[] keyValues) => await _productRepository.FindAsync(keyValues);
        public async Task<List<Product?>> GetAll() => await _productRepository.GetAllAsync();
        public async Task<List<Product>> GetUsersProducts(string userId)=> await _productRepository.GetUsersProducts(userId);
		public async Task<List<Product>> GetSoldProductsOfUser(string userId) => await _productRepository.GetSoldProductsOfUser(userId);
		public async Task<List<Product>> GetOrdersProducts(int orderId) => await _productRepository.GetOrdersProducts(orderId);
		public async Task UpdateAsync(Product product) => await _productRepository.UpdateAsync(product);
    }
}
