using Core.Domain.Entities;
using Core.Domain.Events.DataTypes;
using MediatR;
using Web.Grpc.Contracts.Repositories;
using Web.Grpc.Events;

namespace Web.Grpc.Handler
{
    public class UserCreatedOrUpdatedHandler : IRequestHandler<MessageBody<UserCreatedOrUpdatedData>, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCreatedOrUpdatedHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(MessageBody<UserCreatedOrUpdatedData> dto,
            CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(Guid.Parse(dto.Data.Id));

            if (user != null)
            {
                user.Update(dto);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }

            await _unitOfWork.UserRepository.AddAsync(new User(dto));

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}