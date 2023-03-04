using Grpc.Core;
using MediatR;
using Web.Grpc.Extensions;
using WhatsApp.Web.User.Grpc.Protos.User;

namespace Web.Grpc.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMediator _mediator;

        public UserService(ILogger<UserService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        public override async Task<CreateAccountResponse> CreateAccount(CreateAccountRequest request,
            ServerCallContext context)
        {
            var query = request.ToQuery();

            var userId = await _mediator.Send(query);

            return new CreateAccountResponse
            {
                UserId = userId
            };
        }

        public override async Task<VerifyCodeResponse> VerifyCode(VerifyCodeRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(request.ToQuery());


            return new VerifyCodeResponse
            {
                Id = response.Id,
                PhoneNumber = response.PhoneNumber,
                Token = response.Token
            };
        }


        public override async Task<MessageResponse> SetUpAccount(SetUpAccountRequest request, ServerCallContext context)
        {
            await _mediator.Send(request.ToQuery());


            return new MessageResponse
            {
                Message = "profile updated"
            };
        }

        public override async Task<MessageResponse> UpdateProfile(UpdateProfileRequest request,
            ServerCallContext context)
        {
            await _mediator.Send(request.ToQuery());


            return new MessageResponse
            {
                Message = "profile updated"
            };
        }
    }
}