using Core.Application.Contracts.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        private IOutboxMessageRepository _outboxMessageRepository;

        public IOutboxMessageRepository OutboxMessageRepository
        {
            get
            {
                if (_outboxMessageRepository != null)
                    return _outboxMessageRepository;
                return _outboxMessageRepository = new OutBoxRepository(_appDbContext);
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