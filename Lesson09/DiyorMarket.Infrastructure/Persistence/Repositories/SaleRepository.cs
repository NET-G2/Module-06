using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(DiyorMarketDbContext context)
            : base(context) { }

        public IEnumerable<Sale> FindByCustomerId(int customerId) =>
            _context.Sales
            .Where(s => s.CustomerId == customerId)
            .ToList();
    }
}