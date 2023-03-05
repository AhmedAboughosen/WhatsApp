using MediatR;

namespace Core.Domain.Model.Dto.RequestDto;

public class AddChatFileRequestDto  : IRequest<List<string>>
{
    public string UserId { get; set; }

    public List<string> Base64Image { get; set; }
    public string Extension { get; set; }
}