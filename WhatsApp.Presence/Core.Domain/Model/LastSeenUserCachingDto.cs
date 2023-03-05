namespace Core.Domain.Model
{
    public class LastSeenUserCachingDto
    {
        public LastSeenUserCachingDto()
        {
        }

        public Guid UserId { get; set; }
        public DateTime LastSeen { get; set; }
        
    }
    
}