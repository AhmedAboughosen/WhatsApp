using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Web.Grpc.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
      
        


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