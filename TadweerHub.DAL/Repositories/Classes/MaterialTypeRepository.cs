using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class MaterialTypeRepository : GenericRepository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(TadweerHubDbContext context) : base(context)
        {
        }
    }
}
