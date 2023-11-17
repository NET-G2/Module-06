using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface ISupplyRepository : IRepositoryBase<Supply>
    {
        public IEnumerable<Supply> FindBySupplier(int supplierId);
    }
}
