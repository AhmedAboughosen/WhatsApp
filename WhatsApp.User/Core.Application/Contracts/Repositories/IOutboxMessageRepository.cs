using Core.Domain.Entities;
using Core.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Repositories
{
    public interface IOutboxMessageRepository : IAsyncRepository<OutboxMessage>
    {
        Task AddAsync(List<User> entity);

       
    }
}