using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TadweerHubDbContext Context;
        public GenericRepository(TadweerHubDbContext context)
        {
            Context=new TadweerHubDbContext();
            Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
