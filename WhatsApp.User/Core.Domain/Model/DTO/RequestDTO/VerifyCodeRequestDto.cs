using Core.Domain.Model.DTO.ResponseDto;
using MediatR;

namespace Core.Domain.Model.DTO.RequestDTO
{
    public class VerifyCodeRequestDto  : IRequest<AuthUserInfoResponseDto>
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}