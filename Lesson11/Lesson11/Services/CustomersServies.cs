using Lesson11.Data;
using Lesson11.Models;

namespace Lesson11.Services
{
    public class CustomersServies
    {
        private readonly DiyorMarketDbContext _dbContext;
        public CustomersServies(DiyorMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> GetCustomers() => _dbContext.Customers.ToList();
        public void CreateCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
        public Customer GetCustomerById(int id) => _dbContext.Customers.Find(id);
        public void UpdateCustomer(Customer updateCustomer)
        {
            var customer = _dbContext.Customers.Find(updateCustomer.Id);
            if (customer != null)
            {
                customer.FirstName = updateCustomer.FirstName;
                customer.LastName = updateCustomer.LastName;
                customer.PhoneNumber = updateCustomer.PhoneNumber;
                _dbContext.SaveChanges();
            }
        }
        public void DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }
    }
}
