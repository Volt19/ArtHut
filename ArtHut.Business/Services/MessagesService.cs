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
	public class MessagesService: IMessagesService
	{
        private readonly IMessagesRepository _messagesRepository;

        public MessagesService(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public async Task<Message> SendMessageAsync(Message message) => await _messagesRepository.AddAsync(message);
        public async Task<List<Message>> ReceivedMessagesAsync(string userId) => await _messagesRepository.ReceivedMessagesAsync(userId);
        public async Task<List<Message>> SendedMessagesAsync(string userId) => await _messagesRepository.SendedMessagesAsync(userId);
        public async Task DeleteByIdAsync(int messageId) => await _messagesRepository.DeleteAsync(_messagesRepository.FindAsync(messageId).Result);
        public async Task DeleteAsync(Message message) => await _messagesRepository.DeleteAsync(message);
    }
}
