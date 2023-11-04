using Lesson06.Models;
using Lesson06.Models.Finance;
using Microsoft.EntityFrameworkCore;

namespace Lesson06
{
    internal class Program
    {
        // TPT - Table per Type
        // TPH - Table per hierarchy
        // TPC - Table per concrete type
        static void Main(string[] args)
        {
            Finance();
            // DisplayAllProducts();
        }

        static void Finance()
        {
            using DatabaseContext context = new DatabaseContext();

            var incomes = context.Incomes.ToList();
            var expenses = context.Expenses.ToList();

            int g = 0;

            context.Add(new Income()
            {
                Amount = 500,
                Description = "Salary",
                Date = DateTime.Now
            });

            context.Add(new Expense()
            {
                Amount = 20,
                Description = "Taxi",
                Date = DateTime.Now
            });

            context.SaveChanges();
        }

        // 10 -> 1 -> Category -> 1
        // -> 2 -> Category -> 1

        static void DisplayAllProducts()
        {
            using DatabaseContext context = new();

            var products = context.Products
                .Where(x => x.Price > 1)
                .AsNoTracking();

            foreach(var product in products)
            {
                product.Price *= 10;
            }

            context.Entry(new Product()
            {
                Name = "Sprite",
                Price = 2,
                CategoryId = 1
            }).State = EntityState.Added;

            // context.SaveChanges();

            var product1 = context.Products.FirstOrDefault(x => x.Id == 1);

            int g = 0;

            var sprite = context.Products.FirstOrDefault(x => x.Name == "Sprite");

            context.SaveChanges();

            g = 5;
        }
    }
}