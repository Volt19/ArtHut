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
	public class CountriesRepository : Repository<Country>, ICountriesRepository
	{
		protected ArtHutDbContext Context { get; set; }
		protected DbSet<Country> CountriesEntities { get; set; }
		public CountriesRepository(ArtHutDbContext context) : base(context)
		{
			Context = context;
			CountriesEntities = Context.Set<Country>();
		}
	}
}
