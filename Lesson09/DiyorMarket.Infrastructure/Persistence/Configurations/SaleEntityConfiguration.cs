using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiyorMarket.Infrastructure.Persistence.Configurations
{
    internal class SaleEntityConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable(nameof(Sale));
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            builder.HasMany(s => s.SaleItems)
                .WithOne(si => si.Sale)
                .HasForeignKey(si => si.SaleId);
        }
    }
}
