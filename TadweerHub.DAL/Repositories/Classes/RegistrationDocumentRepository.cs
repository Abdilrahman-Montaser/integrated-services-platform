using Microsoft.EntityFrameworkCore;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class RegistrationDocumentRepository : GenericRepository<RegistrationDocument>, IRegistrationDocumentRepository
    {

        public RegistrationDocumentRepository(TadweerHubDbContext context) : base(context)
        {
        }

        public IReadOnlyList<RegistrationDocument> GetByRequestId(int requestId)
        {
            return context.Set<RegistrationDocument>()
                .AsNoTracking()
                .Where(d => d.RequestId == requestId)
                .OrderBy(d => d.UploadedAt)
                .ToList();
        }

        public void AddRange(IEnumerable<RegistrationDocument> documents)
        {
            context.Set<RegistrationDocument>().AddRange(documents);
        }

        public void RemoveRange(IEnumerable<RegistrationDocument> documents)
        {
            context.Set<RegistrationDocument>().RemoveRange(documents);
        }
    }
}
