using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface ISupplyService
    {
        public IEnumerable<Supply> GetAll();
        public Supply GetById(int id);
        public Supply Create(Supply supply);
        public void Update(Supply supply);
        public void Delete(int id);
    }
}
