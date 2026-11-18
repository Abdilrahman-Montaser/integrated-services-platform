using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Contexts
{
    public class TadweerHubDbContext : DbContext
    {
        public TadweerHubDbContext(DbContextOptions<TadweerHubDbContext> options)
           : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Disputes> Disputes { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        public DbSet<RegistrationDocument> RegistrationDocuments { get; set; }


        public DbSet<Lot> Lots => Set<Lot>();
        public DbSet<LotImage> LotImages => Set<LotImage>();
        public DbSet<MaterialType> MaterialTypes => Set<MaterialType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TadweerHubDbContext).Assembly);
        }

    }
}