using System.Text;
using Core.Application.Contracts.Services;
using Core.Application.Contracts.Services.Publisher;
using Core.Domain.Events;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Infrastructure.MessageBus.Publisher
{
    public class MessageInfoProducer : IMessageInfoPublisher
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly string _exchangeName;
        private readonly string _userService = "ChatService";
        private string _routingKey;

        public MessageInfoProducer(IConfiguration configuration, ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _exchangeName = configuration["MessageBroker:NotificationMessageExchangeName"];
            _routingKey = configuration["MessageBroker:NotificationRoutingKey"];
        }

        public Task SendMessageAsync<T>(MessageBody<T> message)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Direct);

            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            var properties = channel.CreateBasicProperties();

            properties.Type = message.Type;
            properties.AppId = _userService;

            channel.BasicPublish(exchange: _exchangeName, _routingKey, properties, body);

            return Task.CompletedTask;
        }
    }
}