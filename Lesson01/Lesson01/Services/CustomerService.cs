using Lesson01.Models;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace Lesson01.Services
{
    public class CustomerService
    {
        public static string path = "D:\\github darslar\\Module-06\\Lesson01\\Lesson01\\Data\\customersData.json";
        private static List<Customer> _customer = CustomersDiserialize();

        public IEnumerable<Customer> GetCustomers() => _customer;

        public Customer? FindById(int id) => _customer.FirstOrDefault(x => x.Id == id);

        public void Create(Customer customer)
        {
             _customer.Add(customer);
            CustomersSerialization(_customer);
        } 

        public void Update(Customer customerToUpdate)
        {
            var customer = FindById(customerToUpdate.Id);

            if (customer != null)
            {
                customer.Name = customerToUpdate.Name;
                customer.Address = customerToUpdate.Address;
                customer.PhoneNumber = customerToUpdate.PhoneNumber;
                customer.Eamil = customerToUpdate.Eamil;

                CustomersSerialization(_customer);
            }
        }

        public void Delete(int id)
        {
            var customer = FindById(id);
            if (customer != null)
            {
                _customer.Remove(customer);
                CustomersSerialization(_customer);
            } 
        }

        public static List<Customer> CustomersDiserialize()
        {
            var customers = new List<Customer>();

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                customers = JsonSerializer.Deserialize<List<Customer>>(json);

                return customers ?? new List<Customer>();
            }

            return customers;
        }

        private void CustomersSerialization(List<Customer> customer)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();

                string json = JsonSerializer.Serialize(customer, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(path, json);
            }

            else
            {
                string json = JsonSerializer.Serialize(customer, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
        }
    }
}
