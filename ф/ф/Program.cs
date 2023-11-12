using Microsoft.EntityFrameworkCore.Storage;
using ф.Models;

namespace ф
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayAllProducts();
        }

        public static void DisplayAllProducts()
        {
            DatabaseContext context = new DatabaseContext();

            var products = context.Products.AsQueryable();

            products = products.Where(x => x.Price > 1.5m);
            products = products.Where(x => x.Name.Contains("a"));
            products = products.OrderBy(x => x.Price).ThenBy(x => x.Name);

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}