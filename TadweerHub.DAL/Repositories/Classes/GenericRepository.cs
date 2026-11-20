using TadweerHub.DAL.Contexts;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.DAL.Repositories.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TadweerHubDbContext context;
        public GenericRepository(TadweerHubDbContext _context)
        {
            context = _context;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
