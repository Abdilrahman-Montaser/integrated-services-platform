using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IRegistrationDocumentRepository : IGenericRepository<RegistrationDocument>
    {
        IReadOnlyList<RegistrationDocument> GetByRequestId(int requestId);

        void AddRange(IEnumerable<RegistrationDocument> documents);
        void RemoveRange(IEnumerable<RegistrationDocument> documents);
    }
}
