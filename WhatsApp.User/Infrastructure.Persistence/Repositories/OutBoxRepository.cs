using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class OutBoxRepository : AsyncRepository<OutboxMessage>, IOutboxMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public OutBoxRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task AddAsync(List<User> entity)
        {
            var messages = OutboxMessage.ToManyMessages(entity);

            return _appDbContext.OutboxMessages.AddRangeAsync(messages);
        }


        public override Task RemoveAsync(OutboxMessage entity)
        {
            _appDbContext.Attach(entity);

            return base.RemoveAsync(entity);
        }
    }
}