namespace Dashboard.Infrastructure.MessageQueue.Interfaces
{
    public interface IMessageHandler
    {
        void Start(IMessageHandlerCallback callback);
        void Stop();
    }
}
