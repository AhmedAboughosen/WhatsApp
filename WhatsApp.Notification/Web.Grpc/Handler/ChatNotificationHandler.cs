using Core.Domain.Entities;
using Core.Domain.Events.DataTypes;
using MediatR;
using Web.Grpc.Contracts.Repositories;
using Web.Grpc.Contracts.Services;
using Web.Grpc.Events;
using Web.Grpc.Events.DataTypes;
using Web.Grpc.Modles;

namespace Web.Grpc.Handler
{
    public class ChatNotificationHandler : IRequestHandler<MessageBody<ChatNotificationData>, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public ChatNotificationHandler(IUnitOfWork unitOfWork, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }


        public async Task<bool> Handle(MessageBody<ChatNotificationData> dto,
            CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(Guid.Parse(dto.Data.UserId));

            if (user != null)
            {
              
                await _notificationService.SendNotification(new NotificationModel
                {
                    DeviceId = user.DeviceId,
                    Body = dto.Data.Body,
                    Title =dto.Data.Title,
                    IsAndroiodDevice = true
                });

                return true;
            }

            

            return false;
        }
    }
}