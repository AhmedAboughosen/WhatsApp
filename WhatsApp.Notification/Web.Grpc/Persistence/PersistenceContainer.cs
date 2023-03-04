using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Grpc.Contracts.Repositories;
using Web.Grpc.Persistence;

namespace Infrastructure.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {

    
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"), opt =>
                    opt.EnableRetryOnFailure(5,
                        TimeSpan.FromSeconds(30),
                        null)));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}