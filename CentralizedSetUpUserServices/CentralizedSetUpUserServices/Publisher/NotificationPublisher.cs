using System.Text;
using CentralizedSetUpUserServices.Model;
using CentralizedSetUpUserServices.Model.MessageBroker;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CentralizedSetUpUserServices.Publisher
{
    public class NotificationPublisher
    {
        private readonly ConnectionFactory _connectionFactory;
     
        public NotificationPublisher( ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task SendMessageAsync<T>(MessageBody<T> message,PublisherConfigurationModel publisherConfigurationModel)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: publisherConfigurationModel.ExchangeName, type: ExchangeType.Direct);

            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            var properties = channel.CreateBasicProperties();

            properties.Type = message.Type;
            properties.AppId =  publisherConfigurationModel.AppId;

            channel.BasicPublish(exchange: publisherConfigurationModel.ExchangeName, publisherConfigurationModel.RoutingKey, properties, body);

            return Task.CompletedTask;
        }
    }
}