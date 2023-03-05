using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Core.Domain.Model.Dto.Request;
using MediatR;

namespace Infrastructure.Services.Handler
{
    public class LastSeenHandler : IRequestHandler<LastSeenRequestDto, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LastSeenHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(LastSeenRequestDto dto,
            CancellationToken cancellationToken)
        {
            var lastSeen = await _unitOfWork.PresenceRepository.GetAsync(dto.Id);

            if (lastSeen == null)
            {
                var presence = new Presence(dto);

                await _unitOfWork.PresenceRepository.AddAsync(presence);
            }


            lastSeen?.Update(dto.CheckInType);

            await _unitOfWork.SaveChangesAsync();


            return true;
        }
    }
}