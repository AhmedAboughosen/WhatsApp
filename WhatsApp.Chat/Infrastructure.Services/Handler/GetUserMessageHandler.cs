using Core.Application.Contracts.Repositories;
using Core.Domain.Model.DTO.RequestDTO;
using Core.Domain.Model.DTO.ResponseDto;
using MediatR;

namespace Infrastructure.Services.Handler
{
    public class GetUserMessageHandler : IRequestHandler<UserMessageRequestDto, List<UserMessageResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserMessageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<UserMessageResponseDto>> Handle(UserMessageRequestDto dto,
            CancellationToken cancellationToken)
        {
            var chats = await _unitOfWork.UserChatRepository.GetAllAsync(dto.UserId);
            var userGroups = await _unitOfWork.UserGroupRepository.GetAllAsync(dto.UserId);


            var list = new List<UserMessageResponseDto>();

            var userChatList = chats.Select(o => new UserMessageResponseDto
            {
                Title = o.Title,
                DeliveredAt = o.DeliveredAt,
                SeenAt = o.SeenAt,
                SentAt = o.SentAt
            });

            var userGroupList = userGroups.Select(o => new UserMessageResponseDto
            {
                Title = o.Title,
                DeliveredAt = o.DeliveredAt,
                SeenAt = o.SeenAt,
                SentAt = o.SentAt
            });

            list.AddRange(userChatList);
            list.AddRange(userGroupList);
            return userChatList.ToList();
        }
    }
}