using Core.Domain.Model.DTO.RequestDTO;

namespace Core.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; private set; }

        public string GroupName { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }


        public ICollection<User> Users { get; private set; }


        public Group(CreateGroupRequestDto dto)
        {
            Id = Guid.NewGuid();
            Users = dto.Users;
            UserId = dto.CreatedBy;
            GroupName = dto.GroupName;
        }

        public Group()
        {
        }
    }
}