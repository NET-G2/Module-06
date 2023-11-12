using SupermareketInfrstructure.Persistence;
using SupermarketDomain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermareketInfrstructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly SupermarketDbContext _context;

        public RepositoryBase(SupermarketDbContext context)
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
