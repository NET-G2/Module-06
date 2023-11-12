using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface ISupplierService
    {
        public IEnumerable<Supplier> GetAll();
        public Supplier GetById(int id);
        public Supplier Create(Supplier supplier);
        public void Update(Supplier supplier);
        public void Delete(int id);
    }
}
