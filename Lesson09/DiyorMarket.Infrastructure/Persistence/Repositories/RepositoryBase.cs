using DiyorMarket.Domain.Interfaces.Repositories;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DiyorMarketDbContext _context;

        public RepositoryBase(DiyorMarketDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> FindAll()
        {
            var entities = _context.Set<T>().ToList();

            return entities;
        }

        public T FindById(int id)
        {
            var entity = _context.Set<T>().Find(id);

            return entity;
        }

        public T Add(T entity)
        {
            var newEntity = _context.Set<T>().Add(entity);

            return newEntity.Entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
