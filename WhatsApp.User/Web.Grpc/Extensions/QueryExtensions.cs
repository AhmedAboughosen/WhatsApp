using System;
using Core.Domain.Model.DTO.RequestDTO;
using WhatsApp.Web.User.Grpc.Protos.User;

namespace Web.Grpc.Extensions
{
    public static class QueryExtensions
    {
        public static UserRegistrationRequestDto ToQuery(this CreateAccountRequest request)
            => new()
            {
                PhoneNumber = request.PhoneNumber,
                DeviceId = request.DeviceId,
                NotificationsToken = request.NotificationsToken,
                SignToken = request.SignToken
            };

        public static VerifyCodeRequestDto ToQuery(this VerifyCodeRequest request)
            => new()
            {
                Code = request.Token,
                PhoneNumber = request.PhoneNumber,
            }; 
        
        public static UpdateProfileRequestDto ToQuery(this UpdateProfileRequest request)
            => new()
            {
                Dob = request.Dob,
                FullName = request.FullName,
                UserId = request.UserId,
                ProfileUrl = request.ProfileUrl
            };  
        
        public static SetUpAccountRequestDto ToQuery(this SetUpAccountRequest request)
            => new()
            {
                Dob = request.Dob,
                FullName = request.FullName,
                UserId = request.UserId,
                ProfileUrl = request.ProfileUrl
            };  
        
    
    }
}