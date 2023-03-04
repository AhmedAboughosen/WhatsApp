using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Web.API.Model.DTO.RequestDTO;
using Web.API.Model.DTO.ResponseDto;
using WhatsApp.Gateway.Protos.Client.CreateUser;
using WhatsApp.Gateway.Web.Client.User;
using SetUpAccountRequest = WhatsApp.Gateway.Protos.Client.CreateUser.SetUpAccountRequest;

namespace Web.API.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class UserController : BaseController
{
    private readonly User.UserClient _userClient;
    private readonly CreateUser.CreateUserClient _createUserClient;

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, User.UserClient userClient,
        CreateUser.CreateUserClient createUserClient)
    {
        _logger = logger;
        _userClient = userClient;
        _createUserClient = createUserClient;
    }

    [HttpPost()]
    public async Task<string> CreateAccount(UserRegistrationRequestDto dto)
    {
        return await OnExecution(async () =>
        {
            var response = await _userClient.CreateAccountAsync(new CreateAccountRequest
            {
                DeviceId = dto.DeviceId,
                PhoneNumber = dto.PhoneNumber,
                NotificationsToken = dto.NotificationsToken,
                SignToken = dto.SignToken
            });


            return response.UserId;
        });
    }

    [HttpPost("verify-code")]
    public async Task<AuthUserInfoResponseDto> VerifyCode(VerifyCodeRequestDto dto)
    {
        return await OnExecution(async () =>
        {
            var response = await _userClient.VerifyCodeAsync(new VerifyCodeRequest()
            {
                Token = dto.Code,
                PhoneNumber = dto.PhoneNumber,
            });


            return new AuthUserInfoResponseDto
            {
                PhoneNumber = response.PhoneNumber,
                Id = response.Id,
                Token = response.Token
            };
        });
    }

    [HttpPost("setup-account")]
    public async Task<string> SetUpAccount([FromForm] SetUpAccountRequestDto dto)
    {
        return await OnExecution(async () =>
        {
            var response = await _createUserClient.SetUpAccountAsync(
                new SetUpAccountRequest
                {
                    UserId = dto.UserId,
                    Dob = dto.Dob,
                    Extension = dto.Extension,
                    Image = ByteString.FromStream(dto.ProfileImage.OpenReadStream())
                });


            return response.Message;
        });
    }


    [HttpPost("update-Profile")]
    public async Task<string> UpdateProfile(UpdateProfileRequestDto dto)
    {
        return await OnExecution(async () =>
        {
            var response = await _userClient.UpdateProfileAsync(new UpdateProfileRequest()
            {
                Dob = dto.Dob,
                UserId = dto.UserId,
                FullName = dto.FullName
            });
            
            return response.Message;
        });
    }
}