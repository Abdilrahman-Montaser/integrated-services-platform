using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Driver? GetByUserId(int userId, bool includeUser = false);
        Driver? GetByPlateNumber(string plateNumber);
        IReadOnlyList<Driver> GetAvailable(string? governorate = null);
        bool Exists(int userId);
        bool PlateNumberExists(string plateNumber, int? excludeUserId = null);
    }
}
