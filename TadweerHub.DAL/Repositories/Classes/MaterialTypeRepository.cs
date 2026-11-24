using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class MaterialTypeRepository : GenericRepository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(TadweerHubDbContext context) : base(context)
        {
        }
        public MaterialType? GetByName(string name)
        {
            name = name.Trim();
            return context.Set<MaterialType>()
                .AsNoTracking()
                .FirstOrDefault(m => m.Name == name);
        }

        public bool NameExists(string name, int? excludeId = null)
        {
            name = name.Trim();
            return context.Set<MaterialType>()
                .Any(m => m.Name == name &&
                          (excludeId == null || m.MaterialTypeId != excludeId));
        }
        public bool HasLots(int materialTypeId)
        {
            return context.Set<Lot>()
                .IgnoreQueryFilters()
                .Any(l => l.MaterialTypeId == materialTypeId);
        }
    }
}
