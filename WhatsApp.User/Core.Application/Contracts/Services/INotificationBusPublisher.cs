using Core.Domain.Enums;

namespace Core.Application.Contracts.Services
{
    public interface INotificationBusPublisher
    {
        public void StartPublish();
    }
}
