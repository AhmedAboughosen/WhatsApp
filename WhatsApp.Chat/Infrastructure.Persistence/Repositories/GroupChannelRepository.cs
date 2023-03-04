using System;
using System.Threading.Tasks;
using Core.Application.Contracts.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class GroupChannelRepository : AsyncRepository<GroupChannel>, IGroupChannelRepository
    {
        private readonly AppDbContext _appDbContext;

        public GroupChannelRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public Task<bool> AnyAsync(Guid groupId)
            => _appDbContext.GroupChannels.AnyAsync(x => x.Id == groupId);

    }
}