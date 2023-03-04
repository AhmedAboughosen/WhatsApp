using Core.Application.Contracts.Services.Publisher;
using Infrastructure.MessageBus.Listener;
using Infrastructure.MessageBus.Publisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infrastructure.MessageBus
{
    public static class MessageBusContainer
    {
        public static IServiceCollection AddMessageBusRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(s => new ConnectionFactory() {HostName = configuration["MessageBroker:HostName"]});
            services.AddHostedService<UserListener>();
            services.AddScoped<INotificationBusPublisher, NotificationPublisher>();
            services.AddScoped<IMessageInfoPublisher, MessageInfoProducer>();

            return services;
        }
    }
}