using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Model.DTO.ResponseDto;
using MediatR;

namespace Core.Domain.Model.DTO.RequestDTO
{
    public class UserMessageRequestDto : IRequest<List<UserMessageResponseDto>>
    {
        public Guid UserId { get; set; }
    
    }
}