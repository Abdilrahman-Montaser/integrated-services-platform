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
        public DbSet<Dispute> Disputes { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        public DbSet<RegistrationDocument> RegistrationDocuments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<LotImage> LotImages { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TadweerHubDbContext).Assembly);
        }

    }
}