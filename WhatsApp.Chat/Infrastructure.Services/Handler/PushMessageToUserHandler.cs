using Core.Application.Contracts.Repositories;
using Core.Application.Contracts.Services.Publisher;
using Core.Domain.Entities;
using Core.Domain.Model;
using Core.Domain.Model.DTO.RequestDTO;
using MediatR;

namespace Infrastructure.Services.Handler
{
    public class PushMessageToUserHandler : IRequestHandler<NewMessageRequestDto, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationBusPublisher _notificationBusPublisher;

        public PushMessageToUserHandler(IUnitOfWork unitOfWork, INotificationBusPublisher notificationBusPublisher)
        {
            _unitOfWork = unitOfWork;
            _notificationBusPublisher = notificationBusPublisher;
        }


        public async Task<bool> Handle(NewMessageRequestDto dto,
            CancellationToken cancellationToken)
        {
            var channelId = dto.ChatChannelId ?? Guid.NewGuid();

            var message = new Message(dto, channelId);
            // var chat = new ChatChannel(message, channelId, dto.FromUserId);


            var userChat = await _unitOfWork.UserChatRepository.GetAsync(channelId, dto.FromUserId);

            if (userChat == null)
            {
                //first Message between users
                await _unitOfWork.UserChatRepository.AddAsync(new UserChat(channelId, dto.FromUserId, dto.SentAt,
                    dto.DeliveredAt, dto.SeenAt, dto.FullName));
            }
            else
            {
                userChat.Update(dto.SentAt, dto.DeliveredAt, dto.SeenAt);
            }

            await _unitOfWork.MessageRepository.AddAsync(message);

            // await _unitOfWork.ChatChannelRepository.AddAsync(chat);


            await _unitOfWork.OutboxMessageRepository.AddAsync(new OutboxMessage(new NotificationModel
            {
                Title = "message from" + dto.FullName,
                Body = dto.Content,
                UserId = dto.ToUser.ToString(),
                MediaUrl = dto.MediaUrl
            }));

            await _unitOfWork.SaveChangesAsync();


            _notificationBusPublisher.StartPublish();


            return true;
        }
    }
}