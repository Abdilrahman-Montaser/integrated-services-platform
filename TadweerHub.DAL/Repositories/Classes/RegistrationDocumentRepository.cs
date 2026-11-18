using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class RegistrationDocumentRepository : IRegistrationDocumentRepository
    {
        private readonly TadweerHubDbContext _context;

        public RegistrationDocumentRepository(TadweerHubDbContext context)
        {
            _context = context;
        }

        public RegistrationDocument? GetById(int documentId)
        {
            return _context.Set<RegistrationDocument>()
                .FirstOrDefault(d => d.DocumentId == documentId);
        }

        public IReadOnlyList<RegistrationDocument> GetByRequestId(int requestId)
        {
            return _context.Set<RegistrationDocument>()
                .AsNoTracking()
                .Where(d => d.RequestId == requestId)
                .OrderBy(d => d.UploadedAt)
                .ToList();
        }

        public void Add(RegistrationDocument document)
        {
            _context.Set<RegistrationDocument>().Add(document);
        }

        public void AddRange(IEnumerable<RegistrationDocument> documents)
        {
            _context.Set<RegistrationDocument>().AddRange(documents);
        }

        public void Remove(RegistrationDocument document)
        {
            _context.Set<RegistrationDocument>().Remove(document);
        }

        public void RemoveRange(IEnumerable<RegistrationDocument> documents)
        {
            _context.Set<RegistrationDocument>().RemoveRange(documents);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
