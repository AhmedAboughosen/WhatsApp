using Core.Domain.Enums;

namespace Web.API.Model.DTO.ResponseDto
{
    public class GetMessageResponseDto 
    {
        public List<MessageContentResponseDto> MessageContentResponse { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    
    } 
    
    public class MessageContentResponseDto 
    {
        public UserInfoDto UserInfoDto { get; set; }
        public MessageInfoDto MessageInfoDto { get; set; }

    }  
    public class UserInfoDto 
    {
        public String FullName { get; set; }
        public String ProfileImage { get; set; }

    } 
    public class MessageInfoDto 
    {
        public MessageType  MessageType { get; set; }
        public String FullName { get; set; }
        public String Content { get; set; }
        public List<String> MediaList { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime SeenAt { get; set; }
    
    }
}