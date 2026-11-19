using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    internal interface INotificationRepository
    {
        Notification? GetById(int notificationId);
        IEnumerable<Notification> GetByUserId(int userId);
        void Add(Notification notification);
        void Update(Notification notification);
        void Save();
    }
}
