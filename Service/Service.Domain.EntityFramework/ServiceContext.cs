using Cybtans.Entities;
using Cybtans.Entities.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        }


        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Customer> Customers { get; set; }    

        public DbSet<OrderState> OrderStates { get; set; }

        public DbSet<CustomerProfile> CustomerProfiles { get; set; }

        public DbSet<EntityEventLog> EntityEventLogs { get; set; }

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
            
        }
    }
}
