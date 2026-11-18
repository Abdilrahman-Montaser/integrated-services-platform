using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _context;

        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }

        public Driver? GetByUserId(int userId, bool includeUser = false)
        {
            IQueryable<Driver> query = _context.Set<Driver>();

            if (includeUser)
                query = query.Include(d => d.User);

            return query.FirstOrDefault(d => d.UserId == userId);
        }

        public Driver? GetByPlateNumber(string plateNumber)
        {
            return _context.Set<Driver>()
                .FirstOrDefault(d => d.PlateNumber == plateNumber);
        }

        public IReadOnlyList<Driver> GetAll()
        {
            return _context.Set<Driver>()
                .AsNoTracking()
                .Include(d => d.User)
                .ToList();
        }

        public IReadOnlyList<Driver> GetAvailable(string? governorate = null)
        {
            IQueryable<Driver> query = _context.Set<Driver>()
                .AsNoTracking()
                .Where(d => d.IsAvailable);

            if (!string.IsNullOrWhiteSpace(governorate))
                query = query.Where(d => d.Governorate == governorate);

            return query.Include(d => d.User).ToList();
        }

        public bool Exists(int userId)
        {
            return _context.Set<Driver>().Any(d => d.UserId == userId);
        }

        public bool PlateNumberExists(string plateNumber, int? excludeUserId = null)
        {
            return _context.Set<Driver>()
                .Any(d => d.PlateNumber == plateNumber
                               && (excludeUserId == null || d.UserId != excludeUserId));
        }

        public void Add(Driver driver)
        {
            _context.Set<Driver>().Add(driver);
        }

        public void Update(Driver driver)
        {
            _context.Set<Driver>().Update(driver);
        }

        public void Remove(Driver driver)
        {
            _context.Set<Driver>().Remove(driver);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
