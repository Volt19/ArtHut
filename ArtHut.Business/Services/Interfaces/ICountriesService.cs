using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services.Interfaces
{
	public interface ICountriesService
	{
		Task<List<Country>> GetAll();
		Task<Country> GetByIdAsync(int id);
	}
}
