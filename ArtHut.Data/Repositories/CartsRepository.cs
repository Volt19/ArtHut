using ArtHut.Data.Models;
using ArtHut.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Repositories
{
    public class CartsRepository : Repository<Cart>, ICartsRepository
    {
        protected ArtHutDbContext Context { get; set; }
        protected DbSet<Cart> CartsEntities { get; set; }
        public CartsRepository(ArtHutDbContext context) : base(context)
        {
            Context = context;
            CartsEntities = Context.Set<Cart>();
        }
    }
}
