using System.Reflection;
using Core.Application.Contracts.Services;
using Core.Domain.Model.DTO;
using Infrastructure.Services.Sender;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddServicesRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {
          
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<ISmsSender, MessageSender>();
            services.Configure<SmsOptions>(configuration);
            return services;
        }
    }
}