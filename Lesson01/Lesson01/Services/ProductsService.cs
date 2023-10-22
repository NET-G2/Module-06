using System;
using System.Text.Json;
using Lesson01.Models;


namespace Lesson01.Services
{
    public class ProductsService
    {
        private static List<Product> _products = new List<Product>();
        public ProductsService()
        {
            PopulateData();
        }

        public IEnumerable<Product> GetProducts() => _products;

        public Product? FindById(int id) => _products.FirstOrDefault(x => x.Id == id);

        public void Create(Product product) => _products.Add(product);

        public void Update(Product productToUpdate)
        {
            var product = FindById(productToUpdate.Id);

            if (product != null)
            {
                product.Name = productToUpdate.Name;
                product.Description = productToUpdate.Description;
                product.Price = productToUpdate.Price;
            }
        }

        public void Delete(int id)
        {
            var product = FindById(id);
            _products.Remove(product);
        }

        private void PopulateData()
        {
            if (_products.Count > 0)
            {
                return;
            }

            _products.Add(new Product()
            {
                Id = 1,
                Name = "Product A",
                Description = "Description A",
                Price = 10.99m,
            });

            _products.Add(new Product()
            {
                Id = 2,
                Name = "Product B",
                Description = "Description B",
                Price = 19.99m,
            });

            _products.Add(new Product()
            {
                Id = 3,
                Name = "Product C",
                Description = "Description C",
                Price = 5.99m,
            });

            _products.Add(new Product()
            {
                Id = 4,
                Name = "Product D",
                Description = "Description D",
                Price = 15.49m,
            });

            _products.Add(new Product()
            {
                Id = 5,
                Name = "Product E",
                Description = "Description E",
                Price = 12.99m,
            });
        }

        public void SaveProductsToJson()
        {
            string filePath = "C:\\Users\\DELL\\Desktop\\New Matnli hujjat (2).txt\"";
            try
            {
                
                string productsJson = JsonSerializer.Serialize(_products);

               
                File.WriteAllText(filePath, productsJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving products to JSON: {ex.Message}");
            }
        }

    }
}

