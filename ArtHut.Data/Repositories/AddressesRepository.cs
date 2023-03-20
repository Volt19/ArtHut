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
    public class AddressesRepository : Repository<Address>, IAddressesRepository
    {
        public AddressesRepository(ArtHutDbContext context) : base(context)
        {
        }
    }
}
