using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtHut.Data.Repositories
{
    public class TagsRepository : Repository<Tag>, ITagsRepository
    {
        protected ArtHutDbContext Context { get; set; }
        protected DbSet<Tag> TagEntities { get; set; }
        public TagsRepository(ArtHutDbContext context) : base(context)
        {
            Context = context;
            TagEntities = Context.Set<Tag>();
        }
    }
}
