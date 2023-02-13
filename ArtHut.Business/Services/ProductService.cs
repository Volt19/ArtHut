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
    }
}
