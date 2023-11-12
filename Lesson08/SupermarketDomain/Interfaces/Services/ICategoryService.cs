using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Interfaces.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAll();
        public Category GetById(int id);
        public Category Create(Category category);
        public void Update(Category category);
        public void Delete(int id);
    }
}
