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
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(SupermarketDbContext context)
            : base(context){ }
    }
}
