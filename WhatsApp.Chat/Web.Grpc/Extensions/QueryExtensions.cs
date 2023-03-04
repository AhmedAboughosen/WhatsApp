using Core.Domain.Model.DTO.RequestDTO;
using WhatsApp.Web.Chats.Grpc.Protos.Chat;

namespace Web.Grpc.Extensions
{
    public static class QueryExtensions
    {
        public static NewMessageRequestDto ToQuery(this NewMessageRequest request)
            => new()
            {
                FullName = request.FullName,
                ChatChannelId = request.ChatChannelId == null ? null : Guid.Parse(request.ChatChannelId),
                DeliveredAt = request.DeliveredAt.ToDateTime(),
                Content = request.Content,
                MediaUrl = request.MediaUrl.Select(o => o).ToList(),
                Type = request.MessageType == MessageType.Media
                    ? Core.Domain.Enums.MessageType.Media
                    : (
                        request.MessageType == MessageType.Text
                            ? (Core.Domain.Enums.MessageType.MediaWithText)
                            : Core.Domain.Enums.MessageType.MediaWithText),
                SeenAt = request.SeenAt.ToDateTime(),
                SentAt = request.SentAt.ToDateTime(),
                ToUser = Guid.Parse(request.ToUserId),
                FromUserId = Guid.Parse(request.FromUserId)
            };

        public static UserMessageRequestDto ToQuery(this UserChatRequest request)
            => new()
            {
                UserId = Guid.Parse(request.UserId)
            };
    }
}