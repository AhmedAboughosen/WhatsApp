using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UserGroupRepository : AsyncRepository<UserGroup>, IUserGroupRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserGroupRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<bool> AnyAsync(Guid chatId, Guid userId)
            => _appDbContext.UserGroups.AnyAsync(x => x.ChatChannelId == chatId && x.UserId == userId);

        public Task<UserGroup?> GetAsync(Guid chatId, Guid userId)
            => _appDbContext.UserGroups.FirstOrDefaultAsync(x => x.ChatChannelId == chatId && x.UserId == userId);

        public Task<List<UserGroup>> GetAllAsync( Guid userId)
            => _appDbContext.UserGroups.Where(x => x.UserId == userId).ToListAsync();
    }
}