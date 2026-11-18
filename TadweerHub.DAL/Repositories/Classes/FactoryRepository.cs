using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly AppDbContext _context;

        public FactoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Factory? GetByUserId(int userId, bool includeUser = false)
        {
            IQueryable<Factory> query = _context.Set<Factory>();

            if (includeUser)
            {
                query = query.Include(factory => factory.User);
            }

            return query.FirstOrDefault(factory => factory.UserId == userId);
        }

        public IReadOnlyList<Factory> GetAll()
        {
            return _context.Set<Factory>()
                .AsNoTracking()
                .Include(factory => factory.User)
                .OrderBy(factory => factory.CompanyName)
                .ToList();
        }

        public IReadOnlyList<Factory> GetByGovernorate(string governorate)
        {
            return _context.Set<Factory>()
                .AsNoTracking()
                .Where(factory => factory.Governorate == governorate)
                .OrderBy(factory => factory.CompanyName)
                .ToList();
        }

        public bool Exists(int userId)
        {
            return _context.Set<Factory>()
                .Any(factory => factory.UserId == userId);
        }

        public void Add(Factory factory)
        {
            _context.Set<Factory>().Add(factory);
        }

        public void Update(Factory factory)
        {
            _context.Set<Factory>().Update(factory);
        }

        public void Remove(Factory factory)
        {
            _context.Set<Factory>().Remove(factory);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
