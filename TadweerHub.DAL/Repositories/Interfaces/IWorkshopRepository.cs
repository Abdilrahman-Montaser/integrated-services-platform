using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IWorkshopRepository
    {
        Workshop? GetByUserId(int userId, bool includeUser = false);
        IReadOnlyList<Workshop> GetAll();
        IReadOnlyList<Workshop> GetByGovernorate(string governorate);
        bool Exists(int userId);

        void Add(Workshop workshop);
        void Update(Workshop workshop);
        void Remove(Workshop workshop);
        int SaveChanges();
    }
}
