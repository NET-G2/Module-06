using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SupplyItemRepository : RepositoryBase<SupplyItem>, ISupplyItemRepository
    {
        public SupplyItemRepository(DiyorMarketDbContext context)
            : base(context) { }

        public IEnumerable<SupplyItem> FindBySupplyId(int supplyId)
        {
            return _context.SupplyItems
                .Where(si => si.SupplyId == supplyId)
                .ToList();
        }
    }
}
