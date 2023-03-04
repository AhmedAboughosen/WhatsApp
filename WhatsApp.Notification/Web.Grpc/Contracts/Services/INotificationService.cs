using Core.Domain.Model;
using Web.Grpc.Modles;

namespace Web.Grpc.Contracts.Services;

public interface INotificationService
{
    Task<ResponseModel> SendNotification(NotificationModel notificationModel);

}