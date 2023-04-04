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
	public class PaymentsService: IPaymentsService
	{
		private readonly IPaymentsRepository _paymentsRepository;
		public PaymentsService(IPaymentsRepository paymentsRepository)
		{
			_paymentsRepository = paymentsRepository;
		}
		public async Task<Payment> AddPaymentAsync(Payment payment) => await _paymentsRepository.AddAsync(payment);
		public async Task<Payment?> FindAsync(params object[] keyValues) => await _paymentsRepository.FindAsync(keyValues);
	}
}
