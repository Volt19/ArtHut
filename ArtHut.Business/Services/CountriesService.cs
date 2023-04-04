using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Models;
using ArtHut.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services
{
	public class CountriesService : ICountriesService
	{
		private readonly ICountriesRepository _countriesRepository;

		public CountriesService(ICountriesRepository countriesRepository)
		{
			_countriesRepository = countriesRepository;
		}
		public async Task<List<Country>> GetAll() => await _countriesRepository.GetAllAsync();
		public async Task<Country> GetByIdAsync(int id) => await _countriesRepository.FindAsync(id);
	}
}
