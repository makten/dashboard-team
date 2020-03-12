using System.Threading.Tasks;

namespace Dashboard.Infrastructure.MessageQueue.Interfaces
{
    public interface IMessageHandlerCallback
    {
        Task<bool> HandleMessageAsync(string messageType, string body);
    }
}
