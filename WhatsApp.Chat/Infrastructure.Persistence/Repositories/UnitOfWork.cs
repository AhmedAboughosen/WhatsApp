using Core.Application.Contracts.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        private IOutboxMessageRepository? _outboxMessageRepository;

        public IOutboxMessageRepository OutboxMessageRepository
        {
            get
            {
                if (_outboxMessageRepository != null)
                    return _outboxMessageRepository;
                return _outboxMessageRepository = new OutBoxRepository(_appDbContext);
            }
        }

        private IUserChatRepository? _userChatRepository;

        public IUserChatRepository UserChatRepository
        {
            get
            {
                if (_userChatRepository != null)
                    return _userChatRepository;
                return _userChatRepository = new UserChatRepository(_appDbContext);
            }
        }


        private IUserGroupRepository? _userGroupRepository;

        public IUserGroupRepository UserGroupRepository
        {
            get
            {
                if (_userGroupRepository != null)
                    return _userGroupRepository;
                return _userGroupRepository = new UserGroupRepository(_appDbContext);
            }
        }


        private IUserRepository? _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository != null)
                    return _userRepository;
                return _userRepository = new UserRepository(_appDbContext);
            }
        }


        private IMessageRepository? _messageRepository;

        public IMessageRepository MessageRepository
        {
            get
            {
                if (_messageRepository != null)
                    return _messageRepository;
                return _messageRepository = new MessageRepository(_appDbContext);
            }
        }

        private IChatChannelRepository? _chatRepository;

        public IChatChannelRepository ChatChannelRepository
        {
            get
            {
                if (_chatRepository != null)
                    return _chatRepository;
                return _chatRepository = new ChatChannelRepository(_appDbContext);
            }
        }

        private IGroupChannelRepository? _groupChannelRepository;

        public IGroupChannelRepository GroupChannelRepository
        {
            get
            {
                if (_groupChannelRepository != null)
                    return _groupChannelRepository;
                return _groupChannelRepository = new GroupChannelRepository(_appDbContext);
            }
        }

        private IGroupRepository? _groupRepository;

        public IGroupRepository GroupRepository
        {
            get
            {
                if (_groupRepository != null)
                    return _groupRepository;
                return _groupRepository = new GroupRepository(_appDbContext);
            }
        }


        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}