using Core.Domain.Model;

namespace Core.Domain.Entities
{
    public class OutboxMessage
    {
        public OutboxMessage(NotificationModel notificationModel)
        {
            Title = notificationModel.Title;
            ToUserId = notificationModel.UserId;
            Body = notificationModel.Body;
            MediaUrl = notificationModel.MediaUrl.ToArray().ToString();;
        }

        private OutboxMessage()
        {
        }

        public static OutboxMessage FromId(long id) => new() { Id = id };

        public long Id { get; private set; }
        public String ToUserId { get; private set; }
        public String Title { get; private set; }
        public String Body { get; private set; }
        public string? MediaUrl { get; private set; }

        public static IEnumerable<OutboxMessage> ToManyMessages(IEnumerable<NotificationModel> events)
            => events.Select(e => new OutboxMessage(e));
    }
}