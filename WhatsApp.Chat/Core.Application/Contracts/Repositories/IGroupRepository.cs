using System;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IGroupRepository : IAsyncRepository<Group>
    {
        Task<bool> AnyAsync(Guid groupId);
        Task<Group?> GetAsync(Guid groupId);
    }
}