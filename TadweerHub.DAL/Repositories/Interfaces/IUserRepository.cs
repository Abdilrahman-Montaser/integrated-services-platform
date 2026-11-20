using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetByEmail(string email);
        User? GetByPhone(string phone);
        bool EmailExists(string email);
        bool PhoneExists(string phone);
        IReadOnlyList<User> GetByRole(UserRole role);
        IReadOnlyList<User> GetByStatus(UserStatus status);
    }
}
