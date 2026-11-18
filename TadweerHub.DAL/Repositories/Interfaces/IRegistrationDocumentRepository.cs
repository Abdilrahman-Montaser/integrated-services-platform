using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IRegistrationDocumentRepository
    {
        RegistrationDocument? GetById(int documentId);
        IReadOnlyList<RegistrationDocument> GetByRequestId(int requestId);

        void Add(RegistrationDocument document);
        void AddRange(IEnumerable<RegistrationDocument> documents);
        void Remove(RegistrationDocument document);
        void RemoveRange(IEnumerable<RegistrationDocument> documents);
        int SaveChanges();
    }
}
