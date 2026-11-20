using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(TadweerHubDbContext context) : base(context)
        {
        }
        public IEnumerable<Notification> GetByUserId(int userId)
        {
            return context.Set<Notification>()
                .Where(n => n.UserId == userId)
                .ToList();
        }
    }
}