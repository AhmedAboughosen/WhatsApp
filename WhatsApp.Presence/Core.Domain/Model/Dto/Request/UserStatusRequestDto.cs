using Core.Domain.Enums;
using Core.Domain.Model.Dto.Response;
using MediatR;

namespace Core.Domain.Model.Dto.Request
{
    public class UserStatusRequestDto : IRequest<UserStatusResponseDto>
    {
        public Guid Id { get; set; }
    }
}