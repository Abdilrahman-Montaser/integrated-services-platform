using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(TadweerHubDbContext context) : base(context)
        {
        }

        public Driver? GetByUserId(int userId, bool includeUser = false)
        {
            IQueryable<Driver> query = context.Set<Driver>();

            if (includeUser)
                query = query.Include(d => d.User);

            return query.FirstOrDefault(d => d.UserId == userId);
        }

        public Driver? GetByPlateNumber(string plateNumber)
        {
            return context.Set<Driver>()
                .FirstOrDefault(d => d.PlateNumber == plateNumber);
        }

        public IReadOnlyList<Driver> GetAllWithUsers()
        {
            return context.Set<Driver>()
                .AsNoTracking()
                .Include(d => d.User)
                .ToList();
        }

        public IReadOnlyList<Driver> GetAvailable(string? governorate = null)
        {
            IQueryable<Driver> query = context.Set<Driver>()
                .AsNoTracking()
                .Where(d => d.IsAvailable);

            if (!string.IsNullOrWhiteSpace(governorate))
                query = query.Where(d => d.Governorate == governorate);

            return query.Include(d => d.User).ToList();
        }

        public bool Exists(int userId)
        {
            return context.Set<Driver>().Any(d => d.UserId == userId);
        }

        public bool PlateNumberExists(string plateNumber, int? excludeUserId = null)
        {
            return context.Set<Driver>()
                .Any(d => d.PlateNumber == plateNumber
                               && (excludeUserId == null || d.UserId != excludeUserId));
        }
    }
}
