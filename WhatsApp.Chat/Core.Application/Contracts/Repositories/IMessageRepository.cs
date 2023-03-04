using System;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Domain.Model;

namespace Core.Application.Contracts.Repositories
{
    public interface IMessageRepository : IAsyncRepository<Message>
    {
        Task<bool> AnyAsync(Guid messageId);
        Task<PaginatedListModel<Message>>  GetPaginationMessage(Guid channelId,int pageNumber,int pageSize);
    }
}