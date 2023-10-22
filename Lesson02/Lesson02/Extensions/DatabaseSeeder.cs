using Bogus;
using Lesson02.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lesson02.Extensions
{
    public class DatabaseSeeder
    {
        public static void Initialize(IServiceProvider provider)
        {
            var options = provider.GetRequiredService<DbContextOptions<SupermarketDbContext>>();
            using var context = new SupermarketDbContext(options);

            if (context.Products.Any())
            {
                return;
            }

            var faker = new Faker();
            string[] categoryNames = faker.Commerce.Categories(25);

            // ChangeTracker
            foreach (var categoryName in categoryNames)
            {
                context.Categories.Add(new Models.Category()
                {
                    Name = categoryName
                });
            }

            var categories = context.Categories.ToList();

            foreach (var category in categories)
            {
                int randomProductsCount = new Random().Next(5, 20);

                for (int i = 0; i < randomProductsCount; i++)
                {
                    var product = new Models.Product()
                    {
                        Name = faker.Commerce.ProductName(),
                        Price = faker.Random.Decimal(10000, 1000000),
                        CategoryId = category.Id
                    };

                    context.Products.Add(product);
                }
            }

            context.SaveChanges();
        }
    }
}
