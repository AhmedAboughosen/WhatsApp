using Grpc.Core;
using MediatR;
using Web.Grpc.Extensions;
using Web.Grpc.Proto.Media;

namespace Web.Grpc.Services;

public class MediaService : Media.MediaBase
{
    private readonly ILogger<MediaService> _logger;
    private readonly IMediator _mediator;

    public MediaService(ILogger<MediaService> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    public override async Task<UploadProfileImageRequestReply> UploadProfileImage(UploadProfileImageRequest request,
        ServerCallContext context)
    {
        var query = request.ToQuery();

        var profileUrl = await _mediator.Send(query);

        return new UploadProfileImageRequestReply
        {
            ProfileImageUrl = profileUrl
        };
    }
}