using System;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IChatChannelRepository : IAsyncRepository<ChatChannel>
    {
        Task<bool> AnyAsync(Guid id);
    }
}