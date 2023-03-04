using Core.Application.Contracts.Repositories;
using Core.Application.Contracts.Services.Publisher;
using Core.Domain.Entities;
using Core.Domain.Model;
using Core.Domain.Model.DTO.RequestDTO;
using MediatR;

namespace Infrastructure.Services.Handler
{
    public class CreateGroupHandler : IRequestHandler<CreateGroupRequestDto, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationBusPublisher _notificationBusPublisher;

        public CreateGroupHandler(IUnitOfWork unitOfWork, INotificationBusPublisher notificationBusPublisher)
        {
            _unitOfWork = unitOfWork;
            _notificationBusPublisher = notificationBusPublisher;
        }


        public async Task<bool> Handle(CreateGroupRequestDto dto,
            CancellationToken cancellationToken)
        {
            var group = new Group(dto);

            await _unitOfWork.GroupRepository.AddAsync(group);

            //send notification for all users 
            foreach (var user in dto.Users)
            {
                await _unitOfWork.OutboxMessageRepository.AddAsync(new OutboxMessage(new NotificationModel
                {
                    Body = "new group created",
                    Title = dto.GroupName,
                    UserId = user.Id.ToString(),
                    MediaUrl = new List<string>()
                }));
            }


            await _unitOfWork.SaveChangesAsync();

            _notificationBusPublisher.StartPublish();


            return true;
        }
    }
}