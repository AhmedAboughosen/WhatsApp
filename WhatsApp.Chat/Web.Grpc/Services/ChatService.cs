using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Web.Grpc.Extensions;
using WhatsApp.Web.Chats.Grpc.Protos.Chat;

namespace Web.Grpc.Services
{
    public class ChatService : Chat.ChatBase
    {
        private readonly ILogger<ChatService> _logger;
        private readonly IMediator _mediator;

        public ChatService(ILogger<ChatService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        public override async Task<MessageResponse> PushMessageToUser(NewMessageRequest request,
            ServerCallContext context)
        {
            var query = request.ToQuery();

            await _mediator.Send(query);

            return new MessageResponse
            {
                Message = "message Pushed"
            };
        }

        public override async Task<UserChatResponse> UserChats(UserChatRequest request, ServerCallContext context)
        {
            var query = request.ToQuery();

            var response = await _mediator.Send(query);

            RepeatedField<UserChatContentResponse> list = new RepeatedField<UserChatContentResponse>();

            foreach (var chat in response)
            {
                list.Add(new UserChatContentResponse
                {
                    DeliveredAt = chat.DeliveredAt.ToTimestamp(),
                    SeenAt = chat.SeenAt.ToTimestamp(),
                    SentAt = chat.SentAt.ToTimestamp(),
                    Title = chat.Title
                });
            }

            return new UserChatResponse
            {
                Content = { list }
            };
        }
    }
}