using Core.Domain.Enums;
using Core.Domain.Model.Dto.Request;

namespace Core.Domain.Entities
{
    public class Presence
    {
        //user id
        public Guid Id { get; private set; }

        public CheckInType CheckInType { get; private set; }


        public DateTime LastSeen { get; private set; } = DateTime.UtcNow;


        public Presence(LastSeenRequestDto dto)
        {
            Id = dto.Id;
            CheckInType = dto.CheckInType;
        }

        public Presence()
        {
        }
        
        
        public void Update( CheckInType checkInType)
        {
            CheckInType = checkInType;
            LastSeen = DateTime.UtcNow;
        }

    }
}