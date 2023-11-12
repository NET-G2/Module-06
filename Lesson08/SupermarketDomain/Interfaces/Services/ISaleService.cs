using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface ISaleService
    {
        public IEnumerable<Sale> GetAll();
        public Sale GetById(int id);
        public Sale Create(Sale sale);
        public void Update(Sale sale);
        public void Delete(int id);
    }
}
