using System;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IUserGroupRepository : IAsyncRepository<UserGroup>
    {
        Task<bool> AnyAsync(Guid chatId,Guid userId);
        Task<UserGroup?> GetAsync(Guid chatId,Guid userId);
        Task<List<UserGroup>> GetAllAsync(Guid userId);
    }
}