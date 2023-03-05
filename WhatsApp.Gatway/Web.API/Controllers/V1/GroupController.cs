using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Web.API.Model.DTO.RequestDTO;
using Web.API.Model.DTO.ResponseDto;
using Web.Gateway.Proto.Media;
using WhatsApp.Gateway.Protos.Chat;

namespace Web.API.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class GroupController : BaseController
{
    private readonly ILogger<GroupController> _logger;
    private readonly Chat.ChatClient _chatClient;
    private readonly Media.MediaClient _mediaClient;

    public GroupController(ILogger<GroupController> logger, Chat.ChatClient chatClient)
    {
        _logger = logger;
        _chatClient = chatClient;
    }
    

    [HttpPost()]
    public async Task<string> PushMessageToGroup(NewMessageRequestDto dto)
    {
        return await OnExecution(async () =>
        {
            //No Saga pattern (database transaction should be use in v2)
            await Task.CompletedTask;
            var response = await _mediaClient.UploadChatFileAsync(new UploadChatFileRequest
            {
                UserId = dto.FromUserId.ToString(),
                Extension = "png",
            });


            var chatResponse = await _chatClient.PushMessageToGroupAsync(new NewGroupMessageRequest()
            {
                Content = dto.Content,
                DeliveredAt = dto.DeliveredAt.Date.ToTimestamp(),
                SentAt = dto.SentAt.Date.ToTimestamp(),
                SeenAt = dto.SeenAt.Date.ToTimestamp(),
                FullName = dto.FullName,
                FromUserId = dto.FromUserId.ToString(),
                MediaUrl = { response.ImageUrl },
                MessageType = MessageType.Text,
                ChatChannelId = dto.ChatChannelId.ToString(),
                ToUserId = dto.ToUser.ToString()
            });


            return chatResponse.Message;
        });
    }


    [HttpPost("messages")]
    public async Task<GetMessageResponseDto> GetAllMessage(GetMessageRequestDto dto)
    {
        return await OnExecution(async () =>
        {
            var chatResponse = await _chatClient.GetMessagesAsync(new GetMessagesRequest()
            {
                ChannelId = dto.ChannelId.ToString(),
                PageNumber = dto.PageNumber,
                PageSize = dto.PageSize
            });


            return new GetMessageResponseDto
            {
                PageSize = chatResponse.PageSize,
                PageNumber = chatResponse.PageNumber,
                TotalPages = chatResponse.TotalPages,
                MessageContentResponse = chatResponse.MessageContent.Select(o => new MessageContentResponseDto
                {
                    UserInfoDto = new UserInfoDto
                    {
                        FullName = o.UserInfo.FullName,
                        ProfileImage = o.UserInfo.ProfileImage,
                    },
                    MessageInfoDto = new MessageInfoDto
                    {
                        DeliveredAt = o.MessageInfo.DeliveredAt.ToDateTime(),
                        SeenAt = o.MessageInfo.SeenAt.ToDateTime(),
                        SentAt = o.MessageInfo.SentAt.ToDateTime(),
                        Content = o.MessageInfo.Content,
                        MessageType = o.MessageInfo.MessageType == MessageType.Media
                            ? Core.Domain.Enums.MessageType.Media
                            : Core.Domain.Enums.MessageType.Text,
                        MediaList = o.MessageInfo.MediaUrl.ToList()
                    }
                }).ToList()
            };
        });
    }
}