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
    public class AddressesService: IAddressesService
    {
        private readonly IAddressesRepository  _addressesRepository;
        public AddressesService(IAddressesRepository addressesRepository)
        {
            _addressesRepository = addressesRepository;
        }
        public async Task<Address> AddAddressAsync(Address address) => await _addressesRepository.AddAsync(address);
		public async Task<Address?> FindAsync(params object[] keyValues) => await _addressesRepository.FindAsync(keyValues);

	}
}
