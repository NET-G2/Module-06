using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface ISupplyItemService
    {
        public IEnumerable<SupplyItem> GetAll();
        public SupplyItem GetById(int id);
        public SupplyItem Create(SupplyItem supplyItem);
        public void Update(SupplyItem supplyItem);
        public void Delete(int id);
    }
}
