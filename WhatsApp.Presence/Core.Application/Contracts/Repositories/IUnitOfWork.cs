namespace Core.Application.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPresenceRepository PresenceRepository { get; }
        Task SaveChangesAsync();
    }
}