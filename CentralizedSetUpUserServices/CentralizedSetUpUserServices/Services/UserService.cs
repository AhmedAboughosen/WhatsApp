using CentralizedSetUpUserServices.Events;
using CentralizedSetUpUserServices.Events.DataTypes;
using CentralizedSetUpUserServices.Model;
using CentralizedSetUpUserServices.Model.MessageBroker;
using CentralizedSetUpUserServices.Protos.CreateUser;
using CentralizedSetUpUserServices.Publisher;
using Grpc.Core;
using Web.Proto.Media;
using WhatsApp.Create.Grpc.Protos.User;
using MessageResponse = CentralizedSetUpUserServices.Protos.CreateUser.MessageResponse;
using SetUpAccountRequest = CentralizedSetUpUserServices.Protos.CreateUser.SetUpAccountRequest;

namespace CentralizedSetUpUserServices.Services;

public class UserService : CreateUser.CreateUserBase
{
    private readonly ILogger<UserService> _logger;
    private readonly Media.MediaClient _mediaClient;
    private readonly User.UserClient _userClient;
    private readonly NotificationPublisher _notificationPublisher;
    private readonly String _appId;
    private readonly String _exchangeName;
    private readonly String _routingKey;

    public UserService(ILogger<UserService> logger, Media.MediaClient mediaClient, User.UserClient userClient,
        NotificationPublisher notificationPublisher, IConfiguration configuration)
    {
        _logger = logger;
        _mediaClient = mediaClient;
        _userClient = userClient;
        _notificationPublisher = notificationPublisher;
        _appId = configuration["MessageBroker:MediaAppId"];
        _exchangeName = configuration["MessageBroker:MediaExchangeName"];
        _routingKey = configuration["MessageBroker:MediaRoutingKey"];
    }

    public override async Task<MessageResponse> SetUpAccount(SetUpAccountRequest request, ServerCallContext context)
    {
        UploadProfileImageRequestReply mediaResponse;

        try
        {
            //first call media Serivce
            mediaResponse = await _mediaClient.UploadProfileImageAsync(new UploadProfileImageRequest
            {
                UserId = request.UserId,
                Extension = request.Extension,
                Image = request.Image
            });
        }
        catch (RpcException e)
        {
            return new MessageResponse
            {
                Message = e.Message
            };
        }

        try
        {
            //then call user Serivce
            var userResponse = await _userClient.SetUpAccountAsync(
                new WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest()
                {
                    UserId = request.UserId,
                    FullName = request.FullName,
                    Dob = request.Dob,
                    ProfileUrl = mediaResponse.ProfileImageUrl
                });

            
            return new MessageResponse
            {
                Message =userResponse.Message
            };
        }
        catch (RpcException e)
        {
            //Put it On Outbox then send Event To Media Services , to Remove Image.
            await _notificationPublisher.SendMessageAsync(new MessageBody<RemoveProfileImageData>
            {
                DateTime = DateTime.Now,
                Data = new RemoveProfileImageData(request.UserId),
                Type = EventTypes.RemoveProfileImage,
                Sequence = 1,
                Version = 1,
                AggregateId = request.UserId
            }, new PublisherConfigurationModel
            {
                AppId = _appId,
                ExchangeName = _exchangeName,
                RoutingKey = _routingKey
            });
            
            
            return new MessageResponse
            {
                Message = e.Message
            };
        }
    }
}