using System;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IUserChatRepository : IAsyncRepository<UserChat>
    {
        Task<bool> AnyAsync(Guid chatId,Guid userId);
        Task<UserChat?> GetAsync(Guid chatId,Guid userId);
        Task<List<UserChat>> GetAllAsync(Guid userId);
    }
}