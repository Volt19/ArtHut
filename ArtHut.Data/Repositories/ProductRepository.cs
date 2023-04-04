using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtHut.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected ArtHutDbContext Context { get; set; }
        protected DbSet<Product> ProductEntities { get; set; }
        protected DbSet<Photo> PhotoEntities { get; set; }
        public ProductRepository(ArtHutDbContext context) : base(context)
        {
            Context = context;
            ProductEntities = Context.Set<Product>();
            PhotoEntities = Context.Set<Photo>();
        }

        public async Task<List<Product>> GetUsersProducts(string userId)
        {
            var usersProducts = ProductEntities.Where(x=> x.UserId ==userId).ToList();
            return usersProducts;
        }
		public async Task<List<Product>> GetOrdersProducts(int orderId)
		{
			var Products = ProductEntities.Where(x => x.IsSold ==orderId).ToList();
			return Products;
		}
		public async Task<List<Product>> GetSoldProductsOfUser(string userId)
		{
			var Products = ProductEntities.Where(x => x.IsSold !=null && x.UserId==userId).ToList();
			return Products;
		}
	}
}
