using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();


    }
}
