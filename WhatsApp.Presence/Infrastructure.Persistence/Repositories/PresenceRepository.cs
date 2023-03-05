using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PresenceRepository : AsyncRepository<Presence>, IPresenceRepository
    {
        private readonly AppDbContext _appDbContext;

        public PresenceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<bool> AnyAsync(Guid chatId)
            => _appDbContext.Presences.AnyAsync(x => x.Id == chatId);

        public Task<Presence?> GetAsync(Guid id)
            => _appDbContext.Presences.FirstOrDefaultAsync(x => x.Id == id);
    }
}