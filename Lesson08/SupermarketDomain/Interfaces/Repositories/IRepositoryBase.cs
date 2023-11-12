using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        public IEnumerable<T> FindAll();
        public T FindById(int id);
        public T Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public int SaveChanges();
    }
}
