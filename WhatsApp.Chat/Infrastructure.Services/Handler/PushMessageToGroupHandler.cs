using System.Net;
using Core.Application.Contracts.Repositories;
using Core.Application.Contracts.Services.Publisher;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Model;
using Core.Domain.Model.DTO.RequestDTO;
using MediatR;

namespace Infrastructure.Services.Handler
{
    public class PushMessageToGroupHandler : IRequestHandler<NewGroupMessageRequestDto, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationBusPublisher _notificationBusPublisher;

        public PushMessageToGroupHandler(IUnitOfWork unitOfWork, INotificationBusPublisher notificationBusPublisher)
        {
            _unitOfWork = unitOfWork;
            _notificationBusPublisher = notificationBusPublisher;
        }


        public async Task<bool> Handle(NewGroupMessageRequestDto dto,
            CancellationToken cancellationToken)
        {
            var group = await _unitOfWork.GroupRepository.GetAsync(dto.GroupId);

            if (group == null)
            {
                throw new APIException(
                    "user is not exists", HttpStatusCode.NotFound);
            }

            var message = new Message(dto, group.Id);


            var userChat = await _unitOfWork.UserGroupRepository.GetAsync(group.Id, dto.FromUserId);

            if (userChat == null)
            {
                //first Message between users
                await _unitOfWork.UserChatRepository.AddAsync(new UserChat(group.Id, dto.FromUserId, dto.SentAt,
                    dto.DeliveredAt, dto.SeenAt, dto.FullName));
            }
            else
            {
                userChat.Update(dto.SentAt, dto.DeliveredAt, dto.SeenAt);
            }

            
            await _unitOfWork.MessageRepository.AddAsync(message);


            //send notification for all users 
            foreach (var user in group.Users)
            {
                await _unitOfWork.OutboxMessageRepository.AddAsync(new OutboxMessage(new NotificationModel
                {
                    Title = "message from " + dto.FullName,
                    Body = dto.Content,
                    UserId = user.Id.ToString(),
                    MediaUrl = dto.MediaUrl
                }));
            }


            await _unitOfWork.SaveChangesAsync();


            _notificationBusPublisher.StartPublish();


            return true;
        }
    }
}