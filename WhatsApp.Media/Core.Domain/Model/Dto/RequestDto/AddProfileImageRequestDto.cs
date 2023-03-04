using MediatR;

namespace Core.Domain.Model.Dto.RequestDto;

public class AddProfileImageRequestDto  : IRequest<string>
{
    public string UserId { get; set; }

    public string Base64Image { get; set; }
    public string Extension { get; set; }
}