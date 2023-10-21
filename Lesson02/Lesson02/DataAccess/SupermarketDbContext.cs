using Lesson02.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson02.DataAccess
{
    public class SupermarketDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(
            options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Product");
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasColumnType("money");
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>()
                .ToTable("Category");
            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
