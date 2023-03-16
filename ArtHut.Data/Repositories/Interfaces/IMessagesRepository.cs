using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Repositories.Interfaces
{
	public interface IMessagesRepository : IRepository<Message>
	{
		Task<List<Message?>> ReceivedMessagesAsync(string userId);
		Task<List<Message?>> SendedMessagesAsync(string userId);
	}
}
