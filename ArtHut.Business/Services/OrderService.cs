using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using ArtHut.Data.Repositories;
using ArtHut.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services
{
	public class OrderService: IOrderService
	{
		private readonly IOrdersRepository _ordersRepository;
		public OrderService(IOrdersRepository ordersRepository)
		{
			_ordersRepository = ordersRepository;
		}
		public async Task<Order> AddOrderAsync(Order order) => await _ordersRepository.AddAsync(order);
		public async Task<Order?> FindOrderAsync(params object[] keyValues) => await _ordersRepository.FindAsync(keyValues);
		public async Task UpdateAsync(Order order) => await _ordersRepository.UpdateAsync(order);
		public async Task<List<Order>> GetUsersOrdersAsync(string userId) => await _ordersRepository.GetUsersOrdersAsync(userId);

	}
}

