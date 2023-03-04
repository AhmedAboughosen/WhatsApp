using Microsoft.AspNetCore.Mvc;
using Web.API.Model.DTO.RequestDTO;
using Web.API.Model.DTO.ResponseDto;
using WhatsApp.Gateway.Proto.Client.Chat;

namespace Web.API.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class ChatController : BaseController
{
    private readonly ILogger<ChatController> _logger;
    private readonly Chat.ChatClient _chatClient;

    public ChatController(ILogger<ChatController> logger, Chat.ChatClient chatClient)
    {
        _logger = logger;
        _chatClient = chatClient;
    }

    [HttpGet()]
    public async Task<List<UserMessageResponseDto>> GetAllChatsAndGroups(String userId)
    {
        return await OnExecution(async () =>
        {
            var response = await _chatClient.UserChatsAsync(new UserChatRequest()
            {
                UserId = userId
            });


            var list = response.Content.Select(o => new UserMessageResponseDto
            {
                Title = o.Title,
                DeliveredAt = o.DeliveredAt.ToDateTime(),
                SeenAt = o.SeenAt.ToDateTime(),
                SentAt = o.SentAt.ToDateTime()
            }).ToList();

            return list;
        });
    }


    [HttpPost()]
    public async Task<string> AddMessageToUser(NewMessageRequestDto dto)
    {
        return await OnExecution(async () =>
        {
            await Task.CompletedTask;
            // var response = await _userClient.CreateAccountAsync(new CreateAccountRequest
            // {
            //     DeviceId = dto.DeviceId,
            //     PhoneNumber = dto.PhoneNumber,
            //     NotificationsToken = dto.NotificationsToken,
            //     SignToken = dto.SignToken
            // });
            //
            //
            // return response.UserId;
            return "";
        });
    }


    
    [HttpPost("messages")]
    public async Task<AuthUserInfoResponseDto> GetAllMessage(string userId)
    {
        return await OnExecution(async () =>
        {
            return new AuthUserInfoResponseDto();
            // var response = await _userClient.VerifyCodeAsync(new VerifyCodeRequest()
            // {
            //     Token = dto.Code,
            //     PhoneNumber = dto.PhoneNumber,
            // });
            //
            //
            // return new AuthUserInfoResponseDto
            // {
            //     PhoneNumber = response.PhoneNumber,
            //     Id = response.Id,
            //     Token = response.Token
            // };
        });
    }
}