using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IRegistrationRequestRepository : IGenericRepository<RegistrationRequest>
    {
        RegistrationRequest? GetByRequestNo(string requestNo, bool includeDocuments = false);
        IReadOnlyList<RegistrationRequest> GetByUserId(int userId);
        RegistrationRequest? GetLatestByUserId(int userId);
        IReadOnlyList<RegistrationRequest> GetByStatus(RegistrationStatus status);
        IReadOnlyList<RegistrationRequest> GetPending();
        bool RequestNoExists(string requestNo);
        bool HasPendingRequest(int userId);
    }
}
