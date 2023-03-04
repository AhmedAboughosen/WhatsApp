using System;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IMessageRepository : IAsyncRepository<Message>
    {
        Task<bool> AnyAsync(Guid messageId);
    }
}