using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class RegistrationRequestRepository : IRegistrationRequestRepository
    {
    
        private readonly AppDbContext _context;

        public RegistrationRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public RegistrationRequest? GetById(int requestId, bool includeDocuments = false)
        {
            IQueryable<RegistrationRequest> query = _context.Set<RegistrationRequest>();

            if (includeDocuments)
                query = query.Include(r => r.Documents);

            return query.FirstOrDefault(r => r.RequestId == requestId);
        }

        public RegistrationRequest? GetByRequestNo(string requestNo, bool includeDocuments = false)
        {
            IQueryable<RegistrationRequest> query = _context.Set<RegistrationRequest>();

            if (includeDocuments)
                query = query.Include(r => r.Documents);

            return query.FirstOrDefault(r => r.RequestNo == requestNo);
        }

        public IReadOnlyList<RegistrationRequest> GetByUserId(int userId)
        {
            return _context.Set<RegistrationRequest>()
                .AsNoTracking()
                .Include(r => r.Documents)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.SubmittedAt)
                .ToList();
        }

        public RegistrationRequest? GetLatestByUserId(int userId)
        {
            return _context.Set<RegistrationRequest>()
                .Include(r => r.Documents)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.SubmittedAt)
                .FirstOrDefault();
        }

        public IReadOnlyList<RegistrationRequest> GetByStatus(RegistrationStatus status)
        {
            return _context.Set<RegistrationRequest>()
                .AsNoTracking()
                .Include(r => r.User)
                .Include(r => r.Documents)
                .Where(r => r.Status == status)
                .OrderBy(r => r.SubmittedAt)
                .ToList();
        }

        public IReadOnlyList<RegistrationRequest> GetPending()
        {
            return GetByStatus(RegistrationStatus.Pending);
        }

        public bool RequestNoExists(string requestNo)
        {
            return _context.Set<RegistrationRequest>().Any(r => r.RequestNo == requestNo);
        }

        public bool HasPendingRequest(int userId)
        {
            return _context.Set<RegistrationRequest>()
                .Any(r => r.UserId == userId && r.Status == RegistrationStatus.Pending);
        }

        public void Add(RegistrationRequest request)
        {
            _context.Set<RegistrationRequest>().Add(request);
        }

        public void Update(RegistrationRequest request)
        {
            _context.Set<RegistrationRequest>().Update(request);
        }

        public void Remove(RegistrationRequest request)
        {
            _context.Set<RegistrationRequest>().Remove(request);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
