using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces    
{
    public interface IDriverRepository
    {
        Driver? GetByUserId(int userId, bool includeUser = false);
        Driver? GetByPlateNumber(string plateNumber);
        IReadOnlyList<Driver> GetAll();
        IReadOnlyList<Driver> GetAvailable(string? governorate = null);
        bool Exists(int userId);
        bool PlateNumberExists(string plateNumber, int? excludeUserId = null);

        void Add(Driver driver);
        void Update(Driver driver);
        void Remove(Driver driver);
        int SaveChanges();
    }
}
