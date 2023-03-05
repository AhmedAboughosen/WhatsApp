using Core.Domain.Enums;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Web.Grpc.Extensions;
using Web.Grpc.Protos.presence;

namespace Web.Grpc.Services;

public class PresenceService : Presence.PresenceBase
{
    private readonly ILogger<PresenceService> _logger;
    private readonly IMediator _mediator;

    public PresenceService(ILogger<PresenceService> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    public override async Task<MessageReply> CheckIn(CheckInRequest request, ServerCallContext context)
    {
        var query = request.ToQuery();

        await _mediator.Send(query);

        return new MessageReply
        {
            Message = " Pushed"
        };
    }

    public override async Task<MessageReply> CheckOut(CheckOutRequest request, ServerCallContext context)
    {
        var query = request.ToQuery();

        await _mediator.Send(query);

        return new MessageReply
        {
            Message = " Pushed"
        };
    }

    public override async Task<LastStatusReply> LastStatus(LastStatusRequest request, ServerCallContext context)
    {
        var query = request.ToQuery();

        var responseDto = await _mediator.Send(query);

        return new LastStatusReply
        {
            CheckType = responseDto.CheckInType == CheckInType.Out ? CheckType.CheckOut : CheckType.CheckIn,
            LastSeen = responseDto.LastSeen.ToTimestamp()
        };
    }
}