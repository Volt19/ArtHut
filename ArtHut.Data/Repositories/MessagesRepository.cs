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
	public class MessagesRepository : Repository<Message>, IMessagesRepository
	{
        protected ArtHutDbContext Context { get; set; }
        protected DbSet<Message> MassageEntities { get; set; }
        public MessagesRepository(ArtHutDbContext context) : base(context)
        {
            Context = context;
            MassageEntities = Context.Set<Message>();
        }

        public async Task<List<Message?>> ReceivedMessagesAsync(string userId)
        {
            return MassageEntities.Where(x => x.ReceiverId==userId).ToList();
        }
        public async Task<List<Message?>> SendedMessagesAsync(string userId)
        {
            return MassageEntities.Where(x => x.SenderId==userId).ToList();
        }
    }
}
