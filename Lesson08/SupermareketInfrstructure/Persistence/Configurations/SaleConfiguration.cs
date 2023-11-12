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
    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable(nameof(Sale));

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
