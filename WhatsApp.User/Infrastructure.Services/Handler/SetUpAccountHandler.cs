using System.Net;
using Core.Application.Contracts.Repositories;
using Core.Application.Contracts.Services;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Model.DTO.RequestDTO;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Handler
{
    public class SetUpAccountHandler : IRequestHandler<SetUpAccountRequestDto, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationBusPublisher _notificationBusPublisher;

        public SetUpAccountHandler(UserManager<User> userManager, INotificationBusPublisher notificationBusPublisher,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _notificationBusPublisher = notificationBusPublisher;
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(SetUpAccountRequestDto dto,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);

            if (user == null)
            {
                throw new APIException(
                    "user not found", HttpStatusCode.NotFound);
            }

            user.UpdateProfile(dto);

            await _userManager.UpdateAsync(user);

            await _unitOfWork.OutboxMessageRepository.AddAsync(new OutboxMessage(user));

            await _unitOfWork.SaveChangesAsync();

            _notificationBusPublisher.StartPublish();

            return true;
        }
    }
}