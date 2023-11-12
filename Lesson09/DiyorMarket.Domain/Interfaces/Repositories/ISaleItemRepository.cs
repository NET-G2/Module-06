using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface ISaleItemRepository : IRepositoryBase<SaleItem>
    {
        public IEnumerable<SaleItem> FindBySaleId(int saleId);
    }
}
