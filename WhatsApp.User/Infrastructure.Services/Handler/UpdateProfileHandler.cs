using System.Net;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Model.DTO.RequestDTO;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Handler
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileRequestDto, bool>
    {
        private readonly UserManager<User> _userManager;

        public UpdateProfileHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<bool> Handle(UpdateProfileRequestDto dto,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);


            if (user == null)
            {
                throw new APIException(
                    "Invalid Account", HttpStatusCode.NotFound);
            }

            user.UpdateProfile(dto);

            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}