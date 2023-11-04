using Lesson06.Models.Finance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06.Models
{
    internal class DatabaseContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }

        public DatabaseContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=MIRAZIZ\\SQLEXPRESS;Initial Catalog=Lesson06;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region configurations
            modelBuilder.Entity<Category>()
                .Navigation(x => x.Products)
                .AutoInclude();

            modelBuilder.Entity<Category>()
                .HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Drinks"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Sweets"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Fruits"
                });

            modelBuilder.Entity<Product>()
                .HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Coca-Cola",
                    Price = 1.5m,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "Fant",
                    Price = 1.3m,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 3,
                    Name = "Pepsi",
                    Price = 1.5m,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 4,
                    Name = "Sprite",
                    Price = 1.4m,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 5,
                    Name = "Snikers",
                    Price = 2m,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 6,
                    Name = "Mars",
                    Price = 2.2m,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 7,
                    Name = "Twix",
                    Price = 2.3m,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 8,
                    Name = "Apple",
                    Price = 3.5m,
                    CategoryId = 3
                },
                new Product()
                {
                    Id = 9,
                    Name = "Banana",
                    Price = 2m,
                    CategoryId = 3
                },
                new Product()
                {
                    Id = 10,
                    Name = "Orange",
                    Price = 2.3m,
                    CategoryId = 3
                });

            #endregion

            base.OnModelCreating(modelBuilder);

        }
    }
}
