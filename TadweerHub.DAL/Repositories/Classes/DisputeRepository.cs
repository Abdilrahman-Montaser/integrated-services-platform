using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class DisputeRepository : GenericRepository<Dispute>, IDisputeRepository
    {
        public DisputeRepository(TadweerHubDbContext context) : base(context)
        {
        }
    }
}
