using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class FactoryRepository : GenericRepository<Factory>, IFactoryRepository
    {
        public FactoryRepository(TadweerHubDbContext context) : base(context)
        {
        }

        public Factory? GetByUserId(int userId, bool includeUser = false)
        {
            IQueryable<Factory> query = context.Set<Factory>();

            if (includeUser)
            {
                query = query.Include(factory => factory.User);
            }

            return query.FirstOrDefault(factory => factory.UserId == userId);
        }

        public IReadOnlyList<Factory> GetByGovernorate(string governorate)
        {
            return context.Set<Factory>()
                .AsNoTracking()
                .Where(factory => factory.Governorate == governorate)
                .OrderBy(factory => factory.CompanyName)
                .ToList();
        }

        public bool Exists(int userId)
        {
            return context.Set<Factory>()
                .Any(factory => factory.UserId == userId);
        }
    }
}
