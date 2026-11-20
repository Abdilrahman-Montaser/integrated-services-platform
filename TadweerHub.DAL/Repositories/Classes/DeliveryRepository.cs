using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class DeliveryRepository : GenericRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(TadweerHubDbContext context) : base(context)
        {
        }
    }
}
