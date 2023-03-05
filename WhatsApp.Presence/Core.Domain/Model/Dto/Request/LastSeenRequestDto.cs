using Core.Domain.Enums;
using MediatR;

namespace Core.Domain.Model.Dto.Request
{
    public class LastSeenRequestDto : IRequest<bool>
    {
        public Guid Id { get; set; }
        public CheckInType CheckInType { get; set; }
    }
}