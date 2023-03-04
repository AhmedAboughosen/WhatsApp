using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class GroupRepository : AsyncRepository<Group>, IGroupRepository
    {
        private readonly AppDbContext _appDbContext;

        public GroupRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<bool> AnyAsync(Guid groupId)
            => _appDbContext.Groups.AnyAsync(x => x.Id == groupId);

        public Task<Group?> GetAsync(Guid groupId)
            => _appDbContext.Groups.Where(x => x.Id == groupId).Include(o => o.Users).FirstOrDefaultAsync();
    }
}