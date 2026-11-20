using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IWorkshopRepository : IGenericRepository<Workshop>
    {
        Workshop? GetByUserId(int userId, bool includeUser = false);
        IReadOnlyList<Workshop> GetByGovernorate(string governorate);
        bool Exists(int userId);
    }
}
