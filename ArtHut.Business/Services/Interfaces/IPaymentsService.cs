using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Models;

namespace ArtHut.Business.Services.Interfaces
{
	public interface IPaymentsService
	{
		Task<Payment> AddPaymentAsync(Payment payment);
		Task<Payment?> FindAsync(params object[] keyValues);
	}
}
