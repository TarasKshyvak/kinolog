using BLL.Interfaces;
using BLL.Models;
using MassTransit;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public MessageService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendMessage(Message message)
        {
            await _publishEndpoint.Publish(message);
        }
    }
}
