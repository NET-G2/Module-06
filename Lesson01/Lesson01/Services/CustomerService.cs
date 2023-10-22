using Lesson01.Models;
using System.Xml.Linq;

namespace Lesson01.Services
{
    public class CustomerService
    {
        private static List<Customers> _customers = new List<Customers>();
        public CustomerService()
        {
            PopulateData();
        }

        public IEnumerable<Customers> GetCustomers() => _customers;

        public Customers? FindById(int id) => _customers.FirstOrDefault(x => x.Id == id);

        public void Create(Customers customer) => _customers.Add(customer);

        public void Update(Customers customerToUpdate)
        {
            var customer = FindById(customerToUpdate.Id);

            if (customer != null)
            {
                customer.Name = customerToUpdate.Name;
                customer.Age = customerToUpdate.Age;
            }
        }

        public void Delete(int id)
        {
            var customer = FindById(id);
            _customers.Remove(customer);
        }

        private void PopulateData()
        {
            if (_customers.Count > 0)
            {
                return;
            }

            _customers.Add(new Customers()
            {
                Id = 1,
                Name = "ozim",
                Age = 17,
            });

            _customers.Add(new Customers()
            {
                Id = 2,
                Name = "Avazbek",
                Age = 15,
            });

            _customers.Add(new Customers()
            {
                Id = 3,
                Name = "Farxod",
                Age = 17,
            });

            _customers.Add(new Customers()
            {
                Id = 4,
                Name = "Tokhir",
                Age = 24,
            });

            _customers.Add(new Customers()
            {
                Id = 5,
                Name = "Abror",
                Age = 32,
            });
        }
    }
}
