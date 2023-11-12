using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermareketInfrstructure.Persistence.Configurations
{
    internal class SupplyConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.ToTable(nameof(Supply));

            builder.HasKey(su => su.Id);

            builder.Property(su => su.SupplyDate)
                .HasColumnType("date");

            builder.HasOne(su => su.Supplier)
                .WithMany(sp => sp.Supplies)
                .HasForeignKey(su => su.SupplierId);
        }
    }
}
