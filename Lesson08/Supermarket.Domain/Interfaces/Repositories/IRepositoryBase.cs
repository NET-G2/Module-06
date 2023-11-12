namespace Supermarket.Domain.Interfaces.Repositories
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
