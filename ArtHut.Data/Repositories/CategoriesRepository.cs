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
    public class CategoriesRepository: Repository<Category>, ICategoriesRepository
    {
        protected ArtHutDbContext Context { get; set; }
        protected DbSet<Category> CategoriesEntities { get; set; }
        public CategoriesRepository(ArtHutDbContext context) : base(context)
        {
            Context = context;
            CategoriesEntities = Context.Set<Category>();
        }
    }
}
