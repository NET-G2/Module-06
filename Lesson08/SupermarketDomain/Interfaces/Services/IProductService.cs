using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public Product Create(Product product);
        public void Update(Product product);
        public void Delete(int id);
    }
}
