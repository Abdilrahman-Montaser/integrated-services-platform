using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        IEnumerable<Notification> GetByUserId(int userId);
    }
}
