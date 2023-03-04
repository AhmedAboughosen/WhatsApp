using System.Net;
using Core.Application.Contracts.Services;
using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Domain.Exceptions;
using Core.Domain.Model.DTO.RequestDTO;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Handler
{
    public class CreateAccountHandler : IRequestHandler<UserRegistrationRequestDto, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly ISmsSender _smsSender;

        public CreateAccountHandler(UserManager<User> userManager, ISmsSender smsSender)
        {
            _userManager = userManager;
            _smsSender = smsSender;
        }


        public async Task<string> Handle(UserRegistrationRequestDto dto,
            CancellationToken cancellationToken)
        {
            var alreadyExistedUser = await _userManager.Users.FirstOrDefaultAsync(o => o.UserName == dto.PhoneNumber,
                cancellationToken: cancellationToken);

            if (alreadyExistedUser != null)
            {
                alreadyExistedUser.UpdateTokens(dto);

                //send otp to user
                await SendSmsMessage(alreadyExistedUser);

                await _userManager.UpdateAsync(alreadyExistedUser);

                return alreadyExistedUser.Id;
            }


            var user = new User(dto);
            var result = await _userManager.CreateAsync(user);


            if (!result.Succeeded)
            {
                throw new APIException(
                    result.Errors.First().Description, HttpStatusCode.Forbidden);
            }

            await _userManager.AddToRoleAsync(user, Roles.NormalUser.ToString());

            await SendSmsMessage(user);

            return user.Id;
        }


        private async Task SendSmsMessage(User user)
        {
            var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Phone");

            //  var message = "Your security code is: " + code;
            await _smsSender.SendSmsAsync(await _userManager.GetPhoneNumberAsync(user), token);
        }
    }
}