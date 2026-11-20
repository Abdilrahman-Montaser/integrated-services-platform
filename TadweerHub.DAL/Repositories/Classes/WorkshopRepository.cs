using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class WorkshopRepository : GenericRepository<Workshop>, IWorkshopRepository
    {

        public WorkshopRepository(TadweerHubDbContext context) : base(context)
        {
        }

        public Workshop? GetByUserId(int userId, bool includeUser = false)
        {
            IQueryable<Workshop> query = context.Set<Workshop>();

            if (includeUser)
                query = query.Include(w => w.User);

            return query.FirstOrDefault(w => w.UserId == userId);
        }

        public IReadOnlyList<Workshop> GetByGovernorate(string governorate)
        {
            return context.Set<Workshop>()
                .AsNoTracking()
                .Where(w => w.Governorate == governorate)
                .OrderBy(w => w.WorkshopName)
                .ToList();
        }

        public bool Exists(int userId)
        {
            return context.Set<Workshop>().Any(w => w.UserId == userId);
        }
    }
}
