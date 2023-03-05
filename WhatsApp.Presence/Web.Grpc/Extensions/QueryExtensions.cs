using Core.Domain.Enums;
using Core.Domain.Model.Dto.Request;
using Web.Grpc.Protos.presence;

namespace Web.Grpc.Extensions
{
    public static class QueryExtensions
    {
        public static LastSeenRequestDto ToQuery(this CheckInRequest request)
            => new()
            {
                Id = Guid.Parse(request.Id),
                CheckInType = CheckInType.In
            };

        public static LastSeenRequestDto ToQuery(this CheckOutRequest request)
            => new()
            {
                Id = Guid.Parse(request.Id),
                CheckInType = CheckInType.Out
            };
        
        public static UserStatusRequestDto ToQuery(this LastStatusRequest request)
            => new()
            {
                Id = Guid.Parse(request.Id),
            };
    }
}