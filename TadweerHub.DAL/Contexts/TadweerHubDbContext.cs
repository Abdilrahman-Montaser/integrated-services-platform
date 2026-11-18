using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Contexts
{
    public class TadweerHubDbContext(DbContextOptions<TadweerHubDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Lot> Lots => Set<Lot>();
        public DbSet<LotImage> LotImages => Set<LotImage>();
        public DbSet<MaterialType> MaterialTypes => Set<MaterialType>();
    }
}
