using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Models;

namespace ArtHut.Business.Services.Interfaces
{
	public interface IOrderService
	{
	    Task<Order> AddOrderAsync(Order order);
		Task<Order?> FindOrderAsync(params object[] keyValues);
		Task UpdateAsync(Order order);
		Task<List<Order>> GetUsersOrdersAsync(string userId);
	}
}
