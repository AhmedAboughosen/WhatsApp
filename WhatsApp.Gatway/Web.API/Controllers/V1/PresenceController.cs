using Microsoft.AspNetCore.Mvc;
using Web.API.Model.DTO.ResponseDto;
using WhatsApp.Gateway.Protos.Client.presence;

namespace Web.API.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class PresenceController : BaseController
{
    private readonly Presence.PresenceClient _presenceClient;

    private readonly ILogger<PresenceController> _logger;

    public PresenceController(ILogger<PresenceController> logger, Presence.PresenceClient presenceClient)
    {
        _logger = logger;
        _presenceClient = presenceClient;
    }

    [HttpPost("check-in")]
    public async Task<string> CheckIn(String id)
    {
        return await OnExecution(async () =>
        {
            var response = await _presenceClient.CheckInAsync(new CheckInRequest()
            {
                Id = id
            });


            return response.Message;
        });
    }

    [HttpPost("check-out")]
    public async Task<string> CheckOut(String id)
    {
        return await OnExecution(async () =>
        {
            var response = await _presenceClient.CheckOutAsync(new CheckOutRequest()
            {
                Id = id
            });


            return response.Message;
        });
    }

    [HttpPost("last-seen")]
    public async Task<UserStatusResponseDto> LastSeen(String id)
    {
        return await OnExecution(async () =>
        {
            var response = await _presenceClient.LastStatusAsync(new LastStatusRequest()
            {
                Id = id
            });


            return new UserStatusResponseDto
            {
                LastSeen = response.LastSeen.ToDateTime()
            };
        });
    }
}