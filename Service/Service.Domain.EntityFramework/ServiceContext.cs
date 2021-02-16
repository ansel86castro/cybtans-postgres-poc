using Cybtans.Entities;
using Cybtans.Entities.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Service.Domain.EntityFramework
{
    public class ServiceContext : DbContext, IEntityEventLogContext
    {
        public ServiceContext()
        {
        }

        public ServiceContext(DbContextOptions<ServiceContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<EntityEventLog> EntityEventLogs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserFollowings> UserFollowings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Data Source=Service;Mode=Memory;Cache=Shared");
                optionsBuilder.EnableSensitiveDataLogging(true);
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.Property(x => x.Id).ValueGeneratedOnAdd();
                b.HasKey(x => x.Id);

                b.OwnsOne(x => x.Address);

                b.Property(x => x.Settings)
                  .HasColumnType("jsonb");                
              

            });

            modelBuilder.Entity<UserFollowings>(b =>
            {
                b.HasKey(x => new { x.FollowerId, x.FollowingId });

                b.HasOne(x => x.Follower)
                .WithMany(x => x.Followings)
                .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.Following)
                .WithMany(x => x.FollowedBy);

            });
        }
    }
}
