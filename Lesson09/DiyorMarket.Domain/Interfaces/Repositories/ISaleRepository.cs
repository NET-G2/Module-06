using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface ISaleRepository : IRepositoryBase<Sale>
    {
        public IEnumerable<Sale> FindByCustomerId(int customerId);
    }
}
