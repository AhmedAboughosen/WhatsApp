using Core.Domain.Events;

namespace Core.Application.Contracts.Services.Publisher
{
    public interface IMessageProducer
    {
        Task SendMessageAsync<T> (MessageBody<T>  message);
    }
}