using System;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<bool> AnyAsync(Guid userId);
        Task<User?> GetAsync(Guid userId);
    }
}