using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ф.Models.Animals;

namespace ф.Models
{
    internal class DatabaseContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dogs> Dogs { get; set; }
        public virtual DbSet<Chihuahua> Chihuahuas { get; set; }
        public virtual DbSet<Haski> Haskies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DH82C7P;Initial Catalog=lesson06;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    Price = 1.1m,
                    CategoryId = 1,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Pepsi",
                    Price = 1.3m,
                    CategoryId = 1,
                },
                new Product()
                {
                    Id = 3,
                    Name = "Fanta",
                    Price = 1.4m,
                    CategoryId = 1,
                },
                new Product()
                {
                    Id = 4,
                    Name = "Snickers",
                    Price = 1.6m,
                    CategoryId = 2,
                },
                new Product()
                {
                    Id = 5,
                    Name = "Mars",
                    Price = 1.7m,
                    CategoryId = 2,
                },
                new Product()
                {
                    Id = 6,
                    Name = "Twix",
                    Price = 1.8m,
                    CategoryId = 2,
                },
                new Product()
                {
                    Id = 7,
                    Name = "Apple",
                    Price = 2m,
                    CategoryId = 3,
                },
                new Product()
                {
                    Id = 8,
                    Name = "Banana",
                    Price = 2.1m,
                    CategoryId = 3,
                },
                new Product()
                {
                    Id = 9,
                    Name = "Peach",
                    Price = 2.3m,
                    CategoryId = 3,
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
