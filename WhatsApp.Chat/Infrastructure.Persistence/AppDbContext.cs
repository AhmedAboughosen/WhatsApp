using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ChatChannel> ChatChannels { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupChannel> GroupChannels { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }


        public AppDbContext()
        {
        }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}