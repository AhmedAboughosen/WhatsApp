using Core.Domain.Enums;
using MediatR;

namespace Core.Domain.Model.Dto.Response
{
    public class UserStatusResponseDto 
    {
        public DateTime LastSeen { get; set; }
        public CheckInType CheckInType { get; set; }
    }
}