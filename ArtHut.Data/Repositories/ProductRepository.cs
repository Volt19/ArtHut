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
        public ProductRepository(ArtHutDbContext context) : base(context)
        {
            //Context = context;
            //ProductEntities = Context.Set<Product>();
        }
    }
}
