using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IFactoryRepository : IGenericRepository<Factory>
    {
        Factory? GetByUserId(int userId, bool includeUser = false);

        IReadOnlyList<Factory> GetByGovernorate(string governorate);

        bool Exists(int userId);
    }
}
