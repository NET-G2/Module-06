using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface IProductCategoryService
    {
        public IEnumerable<ProductCategory> GetAll();
        public ProductCategory GetById(int id);
        public ProductCategory Create(ProductCategory productCategory);
        public void Update(ProductCategory productCategory);
        public void Delete(int id);
    }
}
