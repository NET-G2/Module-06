using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        public IEnumerable<Supplier> FindByCompany(string company);
    }
}
