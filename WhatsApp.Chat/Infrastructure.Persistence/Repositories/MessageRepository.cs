using System;
using System.Threading.Tasks;
using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Web.Grpc.Extensions;

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

        public async Task<PaginatedListModel<Message>> GetPaginationMessage(Guid channelId,int pageNumber,int pageSize)
        {
            return await (_appDbContext.Messages.Where(o => o.ChatChannelId == channelId).Include(o => o.User)
                .CreateAsync(pageNumber, pageSize));
            
      
        }
    }
}