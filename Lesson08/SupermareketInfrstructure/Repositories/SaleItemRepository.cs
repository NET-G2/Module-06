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
    public class SaleItemRepository : RepositoryBase<SaleItem>, ISaleItemRepository
    {
        public SaleItemRepository(SupermarketDbContext context)
            : base(context){ }
    }
}
