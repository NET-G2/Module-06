using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DiyorMarketDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Supplier> FindByCompany(string company)
        {
            return _context.Suppliers
                .Where(s => s.Company == company)
                .ToList();
        }
    }
}
