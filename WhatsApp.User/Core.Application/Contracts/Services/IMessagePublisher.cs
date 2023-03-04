using System.Threading.Tasks;
using Core.Domain.Model.MessageBroker;

namespace Core.Application.Contracts.Services
{
    public interface IMessageProducer
    {
        Task SendMessageAsync<T> (MessageBody<T>  message);
    }
}