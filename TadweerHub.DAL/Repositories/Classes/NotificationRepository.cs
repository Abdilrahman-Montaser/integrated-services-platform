using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Class
{
    internal class NotificationRepository : INotificationRepository
    {
        private readonly TadweerHubDbContext _context;
        public NotificationRepository(TadweerHubDbContext context)
        {
            _context = context;
        }
       public Notification? GetById(int notificationId)
        {
            return _context.Set<Notification>()
                .FirstOrDefault(n => n.NotificationId == notificationId);
        }
        public IEnumerable<Notification> GetByUserId(int userId)
        {
            return _context.Set<Notification>()
                .Where(n => n.UserId == userId)
                .ToList();
        }
        public void Add(Notification notification)
        {
            _context.Set<Notification>().Add(notification);
        }
        public void Update(Notification notification)
        {
            _context.Set<Notification>().Update(notification);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}