using SupermareketInfrstructure.Persistence;
using SupermarketDomain.Entities;
using SupermarketDomain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermareketInfrstructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(SupermarketDbContext context) 
             : base(context){ }
    }
}
