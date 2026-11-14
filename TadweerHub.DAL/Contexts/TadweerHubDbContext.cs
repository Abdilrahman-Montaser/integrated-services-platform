using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TadweerHub.DAL.Contexts
{
    public class TadweerHubDbContext(DbContextOptions<TadweerHubDbContext> options) : IdentityDbContext(options)
    {
    }
}
