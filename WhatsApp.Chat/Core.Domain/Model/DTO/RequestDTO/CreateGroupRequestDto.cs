using Core.Domain.Entities;
using Core.Domain.Enums;
using MediatR;

namespace Core.Domain.Model.DTO.RequestDTO
{
    public class CreateGroupRequestDto : IRequest<bool>
    {
        public String GroupName { get; set; }
        public List<User> Users { get; set; }
        public Guid CreatedBy { get; set; }
    }
}