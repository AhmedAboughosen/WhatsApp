using Core.Application.Contracts.Repositories;

namespace Web.Grpc.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }
  
        Task SaveChangesAsync();
    }
}