using Core.Domain.Events;

namespace Core.Application.Contracts.Services.BaseService
{
    public interface IMessageHandler
    {
        Task<bool> HandleAsync<T>(MessageBody<T> message);
    }
    
}