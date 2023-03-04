using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Web.Grpc.Persistence;
using Web.Grpc.Persistence.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<bool> AnyAsync(Guid userId)
            => _appDbContext.Users.AnyAsync(x => x.Id == userId);

        public Task<User?> GetAsync(Guid userId)
            => _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        
    }
}