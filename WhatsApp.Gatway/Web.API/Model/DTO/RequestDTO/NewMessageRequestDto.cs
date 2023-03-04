using Core.Domain.Enums;

namespace Web.API.Model.DTO.RequestDTO
{
    public class NewMessageRequestDto 
    {
      
        public Guid FromUserId { get; set; }
        public Guid ToUser { get; set; }
        public String FullName { get; set; }
        public MessageType Type { get; set; }
        public String Content { get; set; }
        public List<IFormFile> Files { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime SeenAt { get; set; }
        
        public Guid? ChatChannelId { get; set; }
    }
}