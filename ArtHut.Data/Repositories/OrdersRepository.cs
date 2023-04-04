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
	public class OrdersRepository : Repository<Order>, IOrdersRepository
	{
		protected ArtHutDbContext Context { get; set; }
		protected DbSet<Order> OrderEntities { get; set; }
		public OrdersRepository(ArtHutDbContext context) : base(context)
		{
			Context = context;
			OrderEntities = Context.Set<Order>();
		}
		public async Task<List<Order?>> GetUsersOrdersAsync(string userId)
		{
			return OrderEntities.Where(x => x.UserId==userId).ToList();
		}
	}
}
