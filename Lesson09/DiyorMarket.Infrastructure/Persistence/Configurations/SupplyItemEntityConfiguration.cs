using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiyorMarket.Infrastructure.Persistence.Configurations
{
    internal class SupplyItemEntityConfiguration : IEntityTypeConfiguration<SupplyItem>
    {
        public void Configure(EntityTypeBuilder<SupplyItem> builder)
        {
            builder.ToTable(nameof(SupplyItem));

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Quantity)
                .IsRequired();

            builder.Property(si => si.UnitPrice)
                .HasColumnType("decimal(18, 2)")  
                .IsRequired();

            builder
                .HasOne(si => si.Supply)
                .WithMany(s => s.SupplyItems)
                .HasForeignKey(si => si.SupplyId)
                .IsRequired();
        }
    }
}
