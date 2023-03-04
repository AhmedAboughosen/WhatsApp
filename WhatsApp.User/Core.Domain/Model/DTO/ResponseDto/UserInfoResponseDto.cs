using System;
using Core.Domain.Enums;

namespace Core.Domain.Model.DTO.ResponseDto
{
    public class UserInfoResponseDto
    {
        public UserInfoResponseDto()
        {
        }

        public String Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Dob { get; set; }
        public String ProfileUrl { get; set; }
        

    }
    
}