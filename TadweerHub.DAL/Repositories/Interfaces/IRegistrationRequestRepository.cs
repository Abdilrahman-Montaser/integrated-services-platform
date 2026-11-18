using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IRegistrationRequestRepository
    {
        RegistrationRequest? GetById(int requestId, bool includeDocuments = false);
        RegistrationRequest? GetByRequestNo(string requestNo, bool includeDocuments = false);
        IReadOnlyList<RegistrationRequest> GetByUserId(int userId);
        RegistrationRequest? GetLatestByUserId(int userId);
        IReadOnlyList<RegistrationRequest> GetByStatus(RegistrationStatus status);
        IReadOnlyList<RegistrationRequest> GetPending();
        bool RequestNoExists(string requestNo);
        bool HasPendingRequest(int userId);

        void Add(RegistrationRequest request);
        void Update(RegistrationRequest request);
        void Remove(RegistrationRequest request);
        int SaveChanges();
    }
}
