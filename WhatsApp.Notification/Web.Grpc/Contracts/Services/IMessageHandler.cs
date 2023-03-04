using Core.Domain.Events;
using Web.Grpc.Events;

namespace Web.Grpc.Contracts.Services
{
    public interface IMessageHandler
    {
        Task<bool> HandleAsync<T>(MessageBody<T> message);
    }
    
}