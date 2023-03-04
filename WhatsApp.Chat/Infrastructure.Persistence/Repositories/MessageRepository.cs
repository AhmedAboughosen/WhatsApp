using System;
using System.Threading.Tasks;
using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class MessageRepository : AsyncRepository<Message>, IMessageRepository
    {
        private readonly AppDbContext _appDbContext;

        public MessageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public Task<bool> AnyAsync(Guid messageId)
            => _appDbContext.Messages.AnyAsync(x => x.Id == messageId);

    }
}