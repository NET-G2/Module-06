using Lesson01.Models;
using Newtonsoft.Json;

namespace Lesson01.Services
{
    public class CustomerService
    {
        private static List<Customer> _customers = new List<Customer>();
        public CustomerService()
        {
           LoadDataFromJson();
        }
        public IEnumerable<Customer> GetCustomers() => _customers;
        public Customer? FindById(int id) => _customers.FirstOrDefault(x => x.Id == id);
        public void Create(Customer customer)
        {
            _customers.Add(customer);
            SaveDataToJson();
        }

        public void Update(Customer customerToUpdate)
        {
            var customer = FindById(customerToUpdate.Id);
            if (customer != null)
            {
                customer.FirstName = customerToUpdate.FirstName;
                customer.LastName = customerToUpdate.LastName;
                customer.Age = customerToUpdate.Age;
                customer.Email = customerToUpdate.Email;
                customer.Phone = customerToUpdate.Phone;
                SaveDataToJson();
            }

        }
        public void Delete(int id)
        {
            var customer = FindById(id);
            _customers.Remove(customer);
            SaveDataToJson();
        }
        public void SaveDataToJson()
        {
            string json = JsonConvert.SerializeObject(_customers, Formatting.Indented);
            File.WriteAllText("customers.json", json);
        }
        public void LoadDataFromJson()
        {
            if (File.Exists("customers.json"))
            {
                string json = File.ReadAllText("customers.json");
                _customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }


    }
}