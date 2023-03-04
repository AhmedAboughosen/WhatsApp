using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Contracts.Services.BaseService;
using Core.Domain.Events;
using Core.Domain.Events.DataTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Infrastructure.MessageBus.Listener
{
    public class UserListener : IHostedService
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger<UserListener> _logger;
        private readonly ConnectionFactory _connectionFactory;
        private IModel _channel;
        private string _exchangeName;

        public UserListener(
            IServiceProvider provider,
            ILogger<UserListener> logger,
            ConnectionFactory connectionFactory,
            IConfiguration configuration)
        {
            _provider = provider;
            _logger = logger;
            _connectionFactory = connectionFactory;
            _exchangeName = configuration["MessageBroker:UserExchangeName"];
        }

        private async void Processor_ProcessMessageAsync(object obj, BasicDeliverEventArgs arg)
        {
            Task<bool> isHandledTask = HandelSubject(arg.BasicProperties.Type, arg);


            var isHandled = await isHandledTask;

            if (isHandled)
            {
                _channel.BasicAck(deliveryTag: arg.DeliveryTag, multiple: false);
                return;
            }
            _channel.BasicNack(deliveryTag: arg.DeliveryTag, false,true);

        }


        private Task<bool> HandelSubject(object subject, BasicDeliverEventArgs message)
        {
            return (subject) switch
            {
                (EventTypes.UserCreatedOrUpdated) => HandleAsync<UserCreatedOrUpdatedData>(message),
                _ => Task.FromResult(true),
            };
        }


        private async Task<bool> HandleAsync<T>(BasicDeliverEventArgs message)
        {
            _logger.LogInformation("Event handling started.");

            var bodyBytes = message.Body.ToArray();

            var json = Encoding.UTF8.GetString(bodyBytes);

            var body = JsonConvert.DeserializeObject<MessageBody<T>>(json);


            using var scope = _provider.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<IMessageHandler>();

            return await handler.HandleAsync(body);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            using var channel = connection.CreateModel();

            _channel = channel;

            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);


            var queueName = _channel.QueueDeclare().QueueName;

            _channel.QueueBind(queue: queueName, exchange: _exchangeName, routingKey: "");

            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Processor_ProcessMessageAsync;

            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

            Console.WriteLine("Consuming");

            Console.ReadKey();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Close();
            return Task.CompletedTask;
        }
    }
}