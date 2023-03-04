namespace Core.Domain.Entities
{
    public class GroupChannel
    {
        public Guid Id { get; private set; }

        public Guid MessageId { get; private set; }
        public Message Message { get; private set; }

        
        public GroupChannel(Message message,Guid id)
        {
            Id = id;
            MessageId = message.Id;
        }

        public GroupChannel()
        {
        }
    }
}