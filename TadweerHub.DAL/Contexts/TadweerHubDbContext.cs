using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Contexts
{
    public class TadweerHubDbContext : DbContext
    {
        public TadweerHubDbContext()
        {
        }

        public TadweerHubDbContext(DbContextOptions<TadweerHubDbContext> options)
           : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
       
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Disputes> Disputes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TadweerHubDbContext).Assembly);
            
        }
        
    }
}

