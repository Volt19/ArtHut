using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services.Interfaces
{
    public interface IAddressesService
    {
        Task<Address> AddAddressAsync(Address address);
        Task<Address?> FindAsync(params object[] keyValues);

	}
}
