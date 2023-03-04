using System;
using System.Threading.Tasks;
using Core.Application.Contracts.Services.BaseService;
using Core.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services.BaseService
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IServiceProvider _provider;

        public MessageHandler(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<bool> HandleAsync<T>(MessageBody<T> message)
        {
            using var scope = _provider.CreateScope();

            var medaiator = scope.ServiceProvider.GetRequiredService<IMediator>();

            return await medaiator.Send(message);
        }
    }
}