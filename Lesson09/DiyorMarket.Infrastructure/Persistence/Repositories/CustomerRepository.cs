using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DiyorMarketDbContext context)
            : base(context)
        {
        }

        public Customer FindByPhone(string phone)
        {
            return _context.Customers.FirstOrDefault(c => c.PhoneNumber.Equals(phone));
        }
    }
}
