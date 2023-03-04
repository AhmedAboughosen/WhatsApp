using Core.Application.Contracts.Repositories;
using Core.Application.Contracts.Services.Publisher;
using Core.Domain.Model.DTO.RequestDTO;
using Core.Domain.Model.DTO.ResponseDto;
using MediatR;

namespace Infrastructure.Services.Handler
{
    public class GetUserMessageHandler : IRequestHandler<UserMessageRequestDto, List<UserMessageResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationBusPublisher _notificationBusPublisher;

        public GetUserMessageHandler(IUnitOfWork unitOfWork, INotificationBusPublisher notificationBusPublisher)
        {
            _unitOfWork = unitOfWork;
            _notificationBusPublisher = notificationBusPublisher;
        }


        public async Task<List<UserMessageResponseDto>> Handle(UserMessageRequestDto dto,
            CancellationToken cancellationToken)
        {
            var chats = await _unitOfWork.UserChatRepository.GetAllAsync(dto.UserId);


            var userChatList = chats.Select(o => new UserMessageResponseDto
            {
                Title = o.Title,
                DeliveredAt = o.DeliveredAt,
                SeenAt = o.SeenAt,
                SentAt = o.SentAt
            });

            return userChatList.ToList();
        }
    }
}