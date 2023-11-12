using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface ISaleItemService
    {
        public IEnumerable<SaleItem> GetAll();
        public SaleItem GetById(int id);
        public SaleItem Create(SaleItem saleItem);
        public void Update(SaleItem saleItem);
        public void Delete(int id);
    }
}
