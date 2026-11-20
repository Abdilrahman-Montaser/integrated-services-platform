using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TadweerHubDbContext context) : base(context)
        {
        }

        public bool EmailExists(string email)
        {
            throw new NotImplementedException();
        }

        public User? GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User? GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<User> GetByRole(UserRole role)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<User> GetByStatus(UserStatus status)
        {
            throw new NotImplementedException();
        }

        public bool PhoneExists(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
