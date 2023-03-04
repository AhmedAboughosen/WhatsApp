namespace Core.Domain.Entities
{
    public class UserGroup
    {
        //user chat id
        public Guid Id { get; private set; }

        public Guid ChatChannelId { get; private set; }

        public string Title { get; private set; }

        public DateTime SentAt { get; set; }

        public DateTime DeliveredAt { get; set; }
        
        public DateTime SeenAt { get; set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }


        public UserGroup(Guid chatChannelId, Guid userId, DateTime sentAt, DateTime deliveredAt,  DateTime seenAt, string title)
        {
            Id = Guid.NewGuid();
            ChatChannelId = chatChannelId;
            UserId = userId;
            Title = title;
            SentAt = sentAt;
            DeliveredAt = deliveredAt;
            SeenAt = seenAt;
        }

        public UserGroup()
        {
        }


        public void Update(DateTime sentAt, DateTime deliveredAt, DateTime seenAt)
        {
            SentAt = sentAt;
            DeliveredAt = deliveredAt;
            SeenAt = seenAt;
        }
    }
}