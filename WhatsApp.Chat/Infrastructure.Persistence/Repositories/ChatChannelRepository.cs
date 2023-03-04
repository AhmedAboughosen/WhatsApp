using System;
using System.Threading.Tasks;
using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ChatChannelRepository : AsyncRepository<ChatChannel>, IChatChannelRepository
    {
        private readonly AppDbContext _appDbContext;

        public ChatChannelRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public Task<bool> AnyAsync(Guid chatId)
            => _appDbContext.ChatChannels.AnyAsync(x => x.Id == chatId);

    }
}