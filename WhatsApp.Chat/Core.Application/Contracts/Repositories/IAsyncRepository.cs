using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Repositories
{
    public interface IAsyncRepository<TDomain> where TDomain : class
    {
        Task AddAsync(TDomain entity);
        Task AddRangeAsync(IEnumerable<TDomain> entities);
        Task RemoveAsync(TDomain entity);
        Task RemoveRangeAsync(IList<TDomain> entities);
        Task<TDomain> FindAsync(string id, bool includeRelated = false);
        Task<TDomain> FindAsync(Guid id, bool includeRelated = false);
        Task<IEnumerable<TDomain>> GetAllAsync();
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TDomain, TResult>> target);
    }
}
