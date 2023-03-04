using MediatR;

namespace Core.Domain.Model.DTO.RequestDTO
{
    public class UserRegistrationRequestDto : IRequest<string>
    {
        public string PhoneNumber { get; set; }
        public string DeviceId { get; set; }
        public string NotificationsToken { get; set; }
        public string SignToken { get; set; }
    }
}