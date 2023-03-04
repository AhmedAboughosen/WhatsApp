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

        public override async Task<MessageListResponse> GetMessages(GetMessagesRequest request,
            ServerCallContext context)
        {
            var query = request.ToQuery();

            var response = await _mediator.Send(query);

            var list = new RepeatedField<MessageContentResponse>();

            foreach (var message in response.MessageContentResponse)
            {
                list.Add(new MessageContentResponse
                {
                    UserInfo = new UserInfo
                    {
                        FullName = message.UserInfoDto.FullName,
                        ProfileImage = message.UserInfoDto.ProfileImage,
                    },
                    MessageInfo = new MessageInfo
                    {
                        DeliveredAt = message.MessageInfoDto.DeliveredAt.ToTimestamp(),
                        SeenAt = message.MessageInfoDto.SeenAt.ToTimestamp(),
                        SentAt = message.MessageInfoDto.SentAt.ToTimestamp(),
                        Content = message.MessageInfoDto.Content,
                    }
                });
            }


            return new MessageListResponse
            {
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalPages = response.TotalPages,
                MessageContent =
                {
                    list
                }
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

        public override async Task<MessageResponse> CreateGroup(CreateGroupRequest request, ServerCallContext context)
        {
            var query = request.ToQuery();

            await _mediator.Send(query);

            return new MessageResponse
            {
                Message = "group created"
            };
        }


        public override async Task<MessageResponse> PushMessageToGroup(NewGroupMessageRequest request,
            ServerCallContext context)
        {
            var query = request.ToQuery();

            await _mediator.Send(query);

            return new MessageResponse
            {
                Message = "message Pushed"
            };
        }

        public override Task<MessageResponse> JoinGroup(JoinGroupRequest request, ServerCallContext context)
        {
            return base.JoinGroup(request, context);
        }

        public override Task<MessageResponse> LeaveGroup(LeaveGroupRequest request, ServerCallContext context)
        {
            return base.LeaveGroup(request, context);
        }
    }
}