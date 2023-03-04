using Infrastructure.MessageBus.Listener;
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
            services.AddHostedService<RemoveProfileImageListener>();
            services.AddSingleton(s => new ConnectionFactory() { HostName = configuration["MessageBroker:HostName"] });

            return services;
        }
    }
}