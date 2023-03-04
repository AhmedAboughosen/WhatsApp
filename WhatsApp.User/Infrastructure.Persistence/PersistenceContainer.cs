using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password = null;
                    opt.User.RequireUniqueEmail = false;
                    opt.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(2));
            
            
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