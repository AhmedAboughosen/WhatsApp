using Core.Application.Contracts.Repositories;
using Core.Domain.Model.DTO.RequestDTO;
using Core.Domain.Model.DTO.ResponseDto;
using MediatR;

namespace Infrastructure.Services.Handler
{
    public class GetMessageListHandler : IRequestHandler<GetMessageRequestDto, GetMessageResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMessageListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<GetMessageResponseDto> Handle(GetMessageRequestDto dto,
            CancellationToken cancellationToken)
        {
            var chats = await _unitOfWork.MessageRepository.GetPaginationMessage(dto.ChannelId, dto.PageNumber,
                dto.PageSize);


            var list = new List<MessageContentResponseDto>();

            foreach (var message in chats.Items)
            {
                list.Add(new MessageContentResponseDto
                {
                    UserInfoDto = new UserInfoDto
                    {
                        FullName = message.User.FullName,
                        ProfileImage = message.User.ProfileUrl,
                    },
                    MessageInfoDto = new MessageInfoDto
                    {
                        DeliveredAt = message.DeliveredAt,
                        SeenAt = message.SeenAt,
                        SentAt = message.SentAt,
                        Content = message.Content,
                        MessageType = message.Type,
                        MediaList = message.MediaUrl.Split(",").ToList()
                    }
                });
            }

            return new GetMessageResponseDto
            {
                PageNumber = chats.PageIndex,
                PageSize = chats.PageSize,
                TotalPages = chats.Count,
                MessageContentResponse = list
            };
        }
    }
}