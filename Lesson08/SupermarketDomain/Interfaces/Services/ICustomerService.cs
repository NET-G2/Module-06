using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAll();
        public Customer GetById(int id);
        public Customer Create(Customer customer);
        public void Update(Customer customer);
        public void Delete(int id);
    }
}
