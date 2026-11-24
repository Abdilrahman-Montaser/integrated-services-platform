using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IMaterialTypeRepository : IGenericRepository<MaterialType>
    {
        MaterialType? GetByName(string name);
        bool NameExists(string name, int? excludeId = null);
        bool HasLots(int materialTypeId);
    }
}
