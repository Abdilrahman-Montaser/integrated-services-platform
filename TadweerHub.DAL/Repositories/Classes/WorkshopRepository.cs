using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class WorkshopRepository : IWorkshopRepository
    {
    
        private readonly AppDbContext _context;

        public WorkshopRepository(AppDbContext context)
        {
            _context = context;
        }

        public Workshop? GetByUserId(int userId, bool includeUser = false)
        {
            IQueryable<Workshop> query = _context.Set<Workshop>();

            if (includeUser)
                query = query.Include(w => w.User);

            return query.FirstOrDefault(w => w.UserId == userId);
        }

        public IReadOnlyList<Workshop> GetAll()
        {
            return _context.Set<Workshop>()
                .AsNoTracking()
                .Include(w => w.User)
                .OrderBy(w => w.WorkshopName)
                .ToList();
        }

        public IReadOnlyList<Workshop> GetByGovernorate(string governorate)
        {
            return _context.Set<Workshop>()
                .AsNoTracking()
                .Where(w => w.Governorate == governorate)
                .OrderBy(w => w.WorkshopName)
                .ToList();
        }

        public bool Exists(int userId)
        {
            return _context.Set<Workshop>().Any(w => w.UserId == userId);
        }

        public void Add(Workshop workshop)
        {
            _context.Set<Workshop>().Add(workshop);
        }

        public void Update(Workshop workshop)
        {
            _context.Set<Workshop>().Update(workshop);
        }

        public void Remove(Workshop workshop)
        {
            _context.Set<Workshop>().Remove(workshop);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
