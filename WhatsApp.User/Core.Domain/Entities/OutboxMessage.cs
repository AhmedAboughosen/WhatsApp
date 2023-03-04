using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Entities
{
    public class OutboxMessage
    {
        private OutboxMessage()
        {
        }

        public OutboxMessage(User user)
        {
            User = @user;
        }

        public static OutboxMessage FromId(long id) => new() { Id = id };

        public long Id { get; private set; }
        public User User { get; private set; }

        public static IEnumerable<OutboxMessage> ToManyMessages(IEnumerable<User> events)
            => events.Select(e => new OutboxMessage(e));
    }
}