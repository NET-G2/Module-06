using Lesson01.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace Lesson01.Services
{
    public class ProductService
    {
        public static string path = "D:\\github darslar\\Module-06\\Lesson01\\Lesson01\\Data\\productsData.json";
        private static List<Product> _product = ProductsDiserialize();

        public IEnumerable<Product> GetProducts() => _product;

        public Product? FindById(int id) => _product.FirstOrDefault(x => x.Id == id);

        public void Create(Product product)
        {
            _product.Add(product);
            ProductsSerialization(_product);
        }

        public void Update(Product productToUpdate)
        {
            var product = FindById(productToUpdate.Id);

            if (product != null)
            {
                product.Name = productToUpdate.Name;
                product.Price = productToUpdate.Price;
                product.Description = productToUpdate.Description;

                ProductsSerialization(_product);
            }

        }

        public void Delete(int id)
        {
            var product = FindById(id);
            if (product != null)
            {
                _product.Remove(product);
                ProductsSerialization(_product);
            }
        }

        public static List<Product> ProductsDiserialize()
        {
            var products = new List<Product>();

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                products = JsonSerializer.Deserialize<List<Product>>(json);

                return products ??  new List<Product>();
            }

            return products;
        }

        public static void ProductsSerialization(List<Product> product)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();

                string json = JsonSerializer.Serialize(product, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(path, json);
            }

            else
            {
                string json = JsonSerializer.Serialize(product, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
        }

    }
}
