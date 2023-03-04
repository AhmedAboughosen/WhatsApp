using System;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IGroupChannelRepository : IAsyncRepository<GroupChannel>
    {
        Task<bool> AnyAsync(Guid groupId);
    }
}