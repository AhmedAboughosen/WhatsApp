namespace Core.Domain.Entities
{
    public class ChatChannel
    {
        //channel id
        public Guid Id { get; private set; }

        public Guid MessageId { get; private set; }
        public Message Message { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }


        public ChatChannel(Message message, Guid channelId, Guid userId)
        {
            Id = channelId;
            UserId = userId;
            MessageId = message.Id;
        }

        public ChatChannel()
        {
        }
    }
}