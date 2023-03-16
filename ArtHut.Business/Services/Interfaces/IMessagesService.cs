using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services.Interfaces
{
	public interface IMessagesService
	{
		Task<Message> SendMessageAsync(Message message);
		Task<List<Message>> SendedMessagesAsync(string userId);
		Task<List<Message>> ReceivedMessagesAsync(string userId);
		Task DeleteByIdAsync(int messageId);
		Task DeleteAsync(Message message);
	}
}
