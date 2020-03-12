using Dashboard.Infrastructure.MessageQueue.Interfaces;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.MessageQueue
{
    public class QueueMessageHandler
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;
        private readonly string _exchange;
        private readonly string _queuename;
        private readonly string _routingkey;
        private IConnection _connection;
        private IModel _model;
        private AsyncEventingBasicConsumer _consumer;
        private string _consumerTag;
        private IMessageHandlerCallback _callback;

        public QueueMessageHandler(string host, string username, string password, string exchange, string queuename, string routingkey)
        {
            _host = host;
            _username = username;
            _password = password;
            _exchange = exchange;
            _queuename = queuename;
            _routingkey = routingkey;
        }

        public void Start(IMessageHandlerCallback callback)
        {
            _callback = callback;

            Policy
                .Handle<Exception>()
                .WaitAndRetry(9, r => TimeSpan.FromSeconds(5), (ex, ts) => { Log.Error("Error connecting to Queueing System. We Will Retry in 5 Seconds"); })
                .Execute(() =>
                {
                    var factory = new ConnectionFactory() { HostName = _host, UserName = _username, Password = _password, DispatchConsumersAsync = true };
                    _connection = factory.CreateConnection();
                    _model = _connection.CreateModel();
                    _model.ExchangeDeclare(_queuename, "fanout", durable: true, autoDelete: false);
                    _model.QueueBind(_queuename, _exchange, _routingkey);
                    _consumer = new AsyncEventingBasicConsumer(_model);
                    _consumer.Received += Consumer_Received;
                    _consumerTag = _model.BasicConsume(_queuename, false, _consumer);
                });

        }

        public void Stop()
        {
            _model.BasicCancel(_consumerTag);
            _model.Close(200, "Goodbye");
            _connection.Close();
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs event_args)
        {
            if (await HandleEvent(event_args))
            {
                _model.BasicAck(event_args.DeliveryTag, false);
            }

        }

        private Task<bool> HandleEvent(BasicDeliverEventArgs event_args)
        {
            // get message type
            string messageType = Encoding.UTF8.GetString((byte[])event_args.BasicProperties.Headers["MessageType"]);

            // Get event message body
            string body = Encoding.UTF8.GetString(event_args.Body);

            return _callback.HandleMessageAsync(messageType, body);
        }
    }
}
