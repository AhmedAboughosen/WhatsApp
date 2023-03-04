
using Core.Domain.Model.MessageBroker;

namespace Core.Application.Contracts.Services.BaseService
{
    public interface IMessageHandler
    {
        Task<bool> HandleAsync<T>(MessageBody<T> message);
    }
    
}