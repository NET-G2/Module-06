using Bogus;
using Bogus.DataSets;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Infrastructure.Persistence;
using DiyorMarket.Infrastructure.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DiyorMarket.Extensions
{
    public static class DatabaseSeeder
    {
        private static Faker _faker = new Faker("ru");

        public static void SeedDatabase(this IServiceCollection services)
        {
            try
            {
                using var context = new DiyorMarketDbContext();

                if (context is null)
                {
                    return;
                }

                CreateProducts(context);
                CreateCategories(context);
                CreateProductCategories(context);
                CreateCustomers(context);
                CreateSales(context);
                CreateSaleItems(context);
                CreateSuppliers(context);
                CreateSupplies(context);
                CreateSupplyItems(context);

                Debug.WriteLine("Database was seeded!");
                int g = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
            }
        }

        private static void CreateProducts(DiyorMarketDbContext context)
        {
            if (context.Products.Any()) return;

            List<Product> products = new List<Product>();

            for(int i = 0; i < 500; i++)
            {
                var incomePrice = _faker.Random.Decimal(1500, 5_000_000);
                var salePrice = _faker.Random.Decimal(incomePrice, incomePrice + 100_000);
                products.Add(new Product()
                {
                    Name = _faker.Commerce.ProductName(),
                    Description = _faker.Commerce.ProductDescription(),
                    ExpireDate = _faker.Date.Between(DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(12)),
                    IncomePrice = incomePrice,
                    SalePrice = salePrice,
                });
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void CreateCategories(DiyorMarketDbContext context)
        {
            if (context.Categories.Any()) return;

            List<string> categoryNames = new List<string>();
            List<Category> categories = new List<Category>();
            int attemps = 0;

            for(int i = 0; i < 25; i++)
            {
                string categoryName = _faker.Commerce.Categories(1)[0];

                while (categoryNames.Contains(categoryName) && attemps < 100)
                {
                    attemps++;
                    categoryName = _faker.Commerce.Categories(1)[0];
                }

                attemps = 0;
                categoryName.Contains(categoryName);
            }

            context.AddRange(categories);
            context.SaveChanges();
        }

        private static void CreateProductCategories(DiyorMarketDbContext context)
        {
            if (context.ProductCategories.Any()) return;

            List<ProductCategory> productCategories = new List<ProductCategory>();
            var products = context.Products.ToList();
            var categories = context.Categories.ToList();

            foreach(var product in products)
            {
                var randomCategory = GetRandomElement(categories);

                productCategories.Add(new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = randomCategory.Id
                });
            }

            context.ProductCategories.AddRange(productCategories);
            context.SaveChanges();
        }

        private static void CreateCustomers(DiyorMarketDbContext context)
        {
            if (context.Customers.Any()) return;
            List<Customer> customers = new List<Customer>();

            for(int i = 0; i < 125; i++)
            {
                customers.Add(new Customer()
                {
                    FirstName = _faker.Name.FirstName(),
                    LastName = _faker.Name.LastName(),
                    PhoneNumber = _faker.Phone.PhoneNumber("+998-##-###-##-##")
                });
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void UpdateCustomers(DiyorMarketDbContext context)
        {
            if (!context.Customers.Any()) return;
            var customers = context.Customers.AsTracking();

            foreach(var customer in customers)
            {
                customer.FirstName = _faker.Name.FirstName();
                customer.LastName = _faker.Name.LastName();
                customer.PhoneNumber = _faker.Phone.PhoneNumber("+998-##-###-##-##");
            }

            context.SaveChanges();
        }

        private static void CreateSales(DiyorMarketDbContext context)
        {
            if (context.Sales.Any()) return;

            var customers = context.Customers.ToList();
            List<Sale> sales = new List<Sale>();

            foreach(var customer in customers)
            {
                int salesCount = new Random().Next(5, 30);
                for(int i = 0; i < salesCount; i++)
                {
                    sales.Add(new Sale()
                    {
                        CustomerId = customer.Id,
                        SaleDate = _faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now),
                    });
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void CreateSaleItems(DiyorMarketDbContext context)
        {
            if (context.SaleItems.Any()) return;

            var sales = context.Sales.ToList();
            var products = context.Products.ToList();
            List<SaleItem> saleItems = new List<SaleItem>();

            foreach(var sale in sales)
            {
                int saleItemsCount = new Random().Next(1, 20);

                for(int i = 0; i < saleItemsCount; i++)
                {
                    var randomProduct = GetRandomElement(products);
                    var quantity = new Random().Next(1, 50);

                    saleItems.Add(new SaleItem()
                    {
                        ProductId = randomProduct.Id,
                        SaleId = sale.Id,
                        Quantity = quantity,
                        UnitPrice = randomProduct.SalePrice,
                    });
                }
            }

            context.SaleItems.AddRange(saleItems);
            context.SaveChanges();
        }

        private static void CreateSuppliers(DiyorMarketDbContext context)
        {
            if (context.Suppliers.Any()) return;
            List<Supplier> suppliers = new List<Supplier>();

            for (int i = 0; i < 125; i++)
            {
                suppliers.Add(new Supplier()
                {
                    FirstName = _faker.Name.FirstName(),
                    LastName = _faker.Name.LastName(),
                    PhoneNumber = _faker.Phone.PhoneNumber("+998-##-###-##-##"),
                    Company = _faker.Company.CompanyName(),
                });
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

        }

        private static void CreateSupplies(DiyorMarketDbContext context)
        {
            if (context.Supplies.Any()) return;

            var suppliers = context.Suppliers.ToList();
            List<Supply> supplies = new List<Supply>();

            foreach (var supplier in suppliers)
            {
                int suppliesCount = new Random().Next(5, 30);
                for (int i = 0; i < suppliesCount; i++)
                {
                    supplies.Add(new Supply()
                    {
                        SupplierId = supplier.Id,
                        SupplyDate = _faker.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now),
                    });
                }
            }

            context.Supplies.AddRange(supplies);
            context.SaveChanges();
        }

        private static void CreateSupplyItems(DiyorMarketDbContext context)
        {
            if (context.SupplyItems.Any()) return;

            var supplies = context.Supplies.ToList();
            var products = context.Products.ToList();
            List<SupplyItem> supplyItems = new List<SupplyItem>();

            foreach (var supply in supplies)
            {
                int supplyItemsCount = new Random().Next(1, 20);

                for (int i = 0; i < supplyItemsCount; i++)
                {
                    var randomProduct = GetRandomElement(products);
                    var quantity = new Random().Next(1, 50);

                    supplyItems.Add(new SupplyItem()
                    {
                        ProductId = randomProduct.Id,
                        SupplyId = supply.Id,
                        Quantity = quantity,
                        UnitPrice = randomProduct.SalePrice,
                    });
                }
            }

            context.SupplyItems.AddRange(supplyItems);
            context.SaveChanges();
        }

        private static T GetRandomElement<T>(ICollection<T> values)
        {
            if (values.Count <= 0)
            {
                return default;
            }

            var randomIndex = new Random().Next(0, values.Count);
            return values.ElementAt(randomIndex);
        }
    }
}
