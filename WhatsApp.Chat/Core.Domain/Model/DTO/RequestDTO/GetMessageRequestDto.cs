using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Model.DTO.ResponseDto;
using MediatR;

namespace Core.Domain.Model.DTO.RequestDTO
{
    public class GetMessageRequestDto : IRequest<GetMessageResponseDto>
    {
        public Guid ChannelId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    
    }
}