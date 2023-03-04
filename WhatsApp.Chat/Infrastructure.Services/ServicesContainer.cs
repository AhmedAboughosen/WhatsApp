using System.Reflection;
using Core.Application.Contracts.Services;
using Core.Application.Contracts.Services.BaseService;
using Core.Domain.Model;
using Core.Domain.Model.DTO;
using CorePush.Apple;
using CorePush.Google;
using Infrastructure.Services.BaseService;
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
            // services.Configure<FcmNotificationSettingModel>(configuration);
            return services;
        }
    }
}