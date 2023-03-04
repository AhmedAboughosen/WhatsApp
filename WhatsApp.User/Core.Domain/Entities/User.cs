using Core.Domain.Enums;
using Core.Domain.Model.DTO.RequestDTO;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; private set; }
        public string Dob { get; private set; }

        public string ProfileUrl { get; private set; }

        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        public State State { get; set; } = State.Active;

        public string DeviceId { get; set; }

        public string NotificationsToken { get; set; }
        
        public string SignToken { get; set; }
        
        public User(UserRegistrationRequestDto dto)
        {
            PhoneNumber = dto.PhoneNumber;
            UserName = dto.PhoneNumber;
            DeviceId = dto.DeviceId;
            NotificationsToken = dto.NotificationsToken;
            SignToken = dto.SignToken;
            TwoFactorEnabled = true;
        }

        public User()
        {
        }


        public void UpdateProfile(SetUpAccountRequestDto setUpAccountRequestDto)
        {
            FullName = setUpAccountRequestDto.FullName;
            Dob = setUpAccountRequestDto.Dob;
            ProfileUrl = setUpAccountRequestDto.ProfileUrl;
        }

        public void UpdateTokens(UserRegistrationRequestDto dto)
        {
            DeviceId = dto.DeviceId;
            NotificationsToken = dto.NotificationsToken;
            SignToken = dto.SignToken;
          
        }

        public void UpdateProfile(UpdateProfileRequestDto setUpAccountRequestDto)
        {
            FullName = setUpAccountRequestDto.FullName;
            Dob = setUpAccountRequestDto.Dob;
          
        }
    }
}