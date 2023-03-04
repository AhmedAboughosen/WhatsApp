using Core.Domain.Model.DTO.RequestDTO;
using MediatR;

namespace Core.Domain.Model.DTO.ResponseDto
{
    public class UserMessageResponseDto 
    {
        public String Title { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime SeenAt { get; set; }
    
    }
}