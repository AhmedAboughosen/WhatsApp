namespace Web.API.Model.DTO.RequestDTO
{
    public class GetMessageRequestDto 
    {
        public Guid ChannelId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    
    }
}