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
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(nameof(Supplier));

            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(sp => sp.LastName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(sp => sp.PhoneNumber)
                .HasColumnType("phone");
        }
    }
}
