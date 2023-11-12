using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiyorMarket.Infrastructure.Persistence.Configurations
{
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(nameof(Supplier));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);  // Adjust the maximum length as needed

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);  // Adjust the maximum length as needed

            builder.Property(s => s.PhoneNumber)
                .HasMaxLength(20);  // Adjust the maximum length as needed

            builder.Property(s => s.Company)
                .HasMaxLength(100);  // Adjust the maximum length as needed

            // Configure the one-to-many relationship with Supply
            builder
                .HasMany(s => s.Supplies)
                .WithOne(sp => sp.Supplier)
                .HasForeignKey(sp => sp.SupplierId)
                .IsRequired();
        }
    }
}