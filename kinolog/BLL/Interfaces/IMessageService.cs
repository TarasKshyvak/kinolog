using BLL.Models;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        Task SendMessage(Message message);
    }
}
