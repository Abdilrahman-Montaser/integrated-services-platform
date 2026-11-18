using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Contexts
{
    public class TadweerHubDbContext : DbContext
    {
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Workshop> Workshops { get; set; }  
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        public DbSet<RegistrationDocument> RegistrationDocuments  { get; set; }
         

    }
}