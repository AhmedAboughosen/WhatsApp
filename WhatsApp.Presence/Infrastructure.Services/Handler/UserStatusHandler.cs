using System.Net;
using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Extensions;
using Core.Domain.Model;
using Core.Domain.Model.Dto.Request;
using Core.Domain.Model.Dto.Response;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Services.Handler
{
    public class UserStatusHandler : IRequestHandler<UserStatusRequestDto, UserStatusResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;

        public UserStatusHandler(IUnitOfWork unitOfWork, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
        }


        public async Task<UserStatusResponseDto> Handle(UserStatusRequestDto dto,
            CancellationToken cancellationToken)
        {

            var lastSeen = await _unitOfWork.PresenceRepository.GetAsync(dto.Id);
            
            if (lastSeen == null)
            {
                throw new APIException(
                    "user is not exists", HttpStatusCode.NotFound);
            }
            
            
            return new UserStatusResponseDto
            {
                CheckInType = lastSeen.CheckInType,
                LastSeen = lastSeen.LastSeen
            };
        }
    }
}