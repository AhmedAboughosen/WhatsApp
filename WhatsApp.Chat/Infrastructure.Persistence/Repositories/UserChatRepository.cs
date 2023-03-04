using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UserChatRepository : AsyncRepository<UserChat>, IUserChatRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserChatRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<bool> AnyAsync(Guid chatId, Guid userId)
            => _appDbContext.UserChats.AnyAsync(x => x.ChatChannelId == chatId && x.UserId == userId);

        public Task<UserChat?> GetAsync(Guid chatId, Guid userId)
            => _appDbContext.UserChats.FirstOrDefaultAsync(x => x.ChatChannelId == chatId && x.UserId == userId);

        public Task<List<UserChat>> GetAllAsync( Guid userId)
            => _appDbContext.UserChats.Where(x => x.UserId == userId).ToListAsync();
    }
}