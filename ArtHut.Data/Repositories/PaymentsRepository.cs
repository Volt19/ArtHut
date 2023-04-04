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
	public class PaymentsRepository : Repository<Payment>, IPaymentsRepository
	{
		protected ArtHutDbContext Context { get; set; }
		protected DbSet<Payment> PaymentEntities { get; set; }
		public PaymentsRepository(ArtHutDbContext context) : base(context)
		{
			Context = context;
			PaymentEntities = Context.Set<Payment>();
		}
	}
}
