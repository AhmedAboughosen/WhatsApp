using Core.Application.Contracts.Repositories;
using Web.Grpc.Contracts.Repositories;
using Web.Grpc.Persistence;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        private IUserRepository? _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository != null)
                    return _userRepository;
                return _userRepository = new UserRepository(_appDbContext);
            }
        }


       

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}