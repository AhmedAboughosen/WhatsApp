using Core.Domain.Enums;
using Core.Domain.Model.DTO.RequestDTO;

namespace Core.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; private set; }
        public MessageType Type { get; private set; }
        public string? Content { get; private set; }
        public string? MediaUrl { get; private set; }
        public DateTime SentAt { get; private set; }
        public DateTime DeliveredAt { get; private set; }
        public DateTime SeenAt { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }


        public Guid? ChatChannelId { get; private set; }

        public Guid? GroupId { get; private set; }
        public Group Group { get; private set; }

        public Message(NewMessageRequestDto dto, Guid chatId)
        {
            Id = Guid.NewGuid();
            Type = dto.Type;
            Content = dto.Content;
            MediaUrl = dto.MediaUrl.ToArray().ToString();
            SentAt = dto.SentAt;
            DeliveredAt = dto.DeliveredAt;
            SeenAt = dto.SeenAt;
            UserId = dto.FromUserId;
            ChatChannelId = chatId;
        }

        public Message(NewGroupMessageRequestDto dto, Guid groupId)
        {
            Id = Guid.NewGuid();
            Type = dto.Type;
            Content = dto.Content;
            MediaUrl = dto.MediaUrl.ToArray().ToString();
            SentAt = dto.SentAt;
            DeliveredAt = dto.DeliveredAt;
            SeenAt = dto.SeenAt;
            UserId = dto.FromUserId;
            GroupId = groupId;
        }

        public Message()
        {
        }
    }
}