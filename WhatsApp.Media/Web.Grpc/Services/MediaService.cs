using Google.Protobuf.Collections;
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


    public override async Task<UploadProfileImageReply> UploadProfileImage(UploadProfileImageRequest request,
        ServerCallContext context)
    {
        var query = request.ToQuery();

        var profileUrl = await _mediator.Send(query);

        return new UploadProfileImageReply
        {
            ProfileImageUrl = profileUrl
        };
    }

    public override async Task<UploadChatFileReply> UploadChatFile(UploadChatFileRequest request,
        ServerCallContext context)
    {
        var query = request.ToQuery();

        var files = await _mediator.Send(query);

        RepeatedField<string> list = new RepeatedField<string>();


        foreach (var url in files)
        {
            list.Add(url);
        }

        return new UploadChatFileReply
        {
            ImageUrl = { list }
        };
    }
}