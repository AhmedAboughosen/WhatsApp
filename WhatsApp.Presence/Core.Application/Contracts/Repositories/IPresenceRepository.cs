using Core.Domain.Entities;

namespace Core.Application.Contracts.Repositories
{
    public interface IPresenceRepository : IAsyncRepository<Presence>
    {
        Task<bool> AnyAsync(Guid id);
        Task<Presence?> GetAsync(Guid id);
    }
}