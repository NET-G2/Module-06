using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SaleItemRepository : RepositoryBase<SaleItem>, ISaleItemRepository
    {
        public SaleItemRepository(DiyorMarketDbContext context) 
            : base(context)
        { }

        public IEnumerable<SaleItem> FindBySaleId(int saleId)
        {
            return _context.SaleItems
                .Where(si => si.SaleId == saleId)
                .ToList();
        }
    }
}
