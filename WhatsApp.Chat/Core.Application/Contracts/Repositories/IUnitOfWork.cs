namespace Core.Application.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IMessageRepository MessageRepository { get; }
        IChatChannelRepository ChatChannelRepository { get; }
        IGroupChannelRepository GroupChannelRepository { get; }
        IGroupRepository GroupRepository { get; }
        IOutboxMessageRepository OutboxMessageRepository { get; }
        IUserChatRepository UserChatRepository { get; }
        IUserGroupRepository UserGroupRepository { get; }
        Task SaveChangesAsync();
    }
}