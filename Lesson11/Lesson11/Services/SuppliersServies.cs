using Lesson11.Data;
using Lesson11.Models;

namespace Lesson11.Services
{
    public class SuppliersServies
    {
        private readonly DiyorMarketDbContext _dbContext;
        public SuppliersServies(DiyorMarketDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public IEnumerable<Supplier> GetSuplier() => _dbContext.Suppliers.ToList();
        public void CreateSupplier(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
        }
        public Supplier GetSupplierById(int id) => _dbContext.Suppliers.Find(id);
        public void UpdateSuppliers(Supplier updateSupplier)
        {
            var supplier = _dbContext.Suppliers.Find(updateSupplier.Id);
            if (supplier != null)
            {
                supplier.FullName = updateSupplier.FullName;
                supplier.PhoneNumber = updateSupplier.PhoneNumber;
                supplier.Company = updateSupplier.Company;

                _dbContext.SaveChanges();
            }
        }
        public void DeleteSupplier(int id)
        {
            var supplier = _dbContext.Suppliers.Find(id);
            if (supplier != null)
            {
                _dbContext.Suppliers.Remove(supplier);
                _dbContext.SaveChanges();
            }
        }
    }
}
