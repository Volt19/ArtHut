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
    }
}
