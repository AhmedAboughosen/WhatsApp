using MediatR;

namespace Core.Domain.Model.DTO.RequestDTO
{
    public class UpdateProfileRequestDto  : IRequest<bool>
    {
        public string FullName { get; set; }
        public string ProfileUrl { get; set; }
        public string Dob { get; set; }
        
        public string UserId { get; set; }
    }
}