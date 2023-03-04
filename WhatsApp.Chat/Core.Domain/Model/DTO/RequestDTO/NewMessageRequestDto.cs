using Core.Domain.Enums;
using MediatR;

namespace Core.Domain.Model.DTO.RequestDTO
{
    public class NewMessageRequestDto : IRequest<bool>
    {
      
        public Guid FromUserId { get; set; }
        public Guid ToUser { get; set; }
        public String FullName { get; set; }
        public MessageType Type { get; set; }
        public String Content { get; set; }
        public List<String> MediaUrl { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime SeenAt { get; set; }
        
        public Guid? ChatChannelId { get; set; }
    }
}