using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Repositories.Interfaces
{
	public interface IOrdersRepository : IRepository<Order>
	{
		Task<List<Order?>> GetUsersOrdersAsync(string userId);
	}
}
