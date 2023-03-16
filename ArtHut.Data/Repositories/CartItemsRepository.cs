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
    public class CartItemsRepository : Repository<CartItem>, ICartItemsRepository
    {
        protected ArtHutDbContext Context { get; set; }
        protected DbSet<CartItem> CartItemsEntities { get; set; }
        public CartItemsRepository(ArtHutDbContext context) : base(context)
        {
            Context = context;
            CartItemsEntities = Context.Set<CartItem>();
        }

        public async Task<List<CartItem?>> GetCartAsync(string userId)
        {
            return CartItemsEntities.Where(x => x.UserId==userId && x.IsSold==true).ToList();
        }
    }
}
