using System.Collections.Generic;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IFactoryRepository
    {
        Factory? GetByUserId(int userId, bool includeUser = false);

        IReadOnlyList<Factory> GetAll();

        IReadOnlyList<Factory> GetByGovernorate(string governorate);

        bool Exists(int userId);

        void Add(Factory factory);

        void Update(Factory factory);

        void Remove(Factory factory);
        void Delete(int userId);

        int SaveChanges();
    }
}
