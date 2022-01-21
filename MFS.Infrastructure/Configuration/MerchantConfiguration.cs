using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFS.Domain.MerchantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFS.Infrastructure.Configuration
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.HasKey(q => q.Id);

            builder
                .Property(q => q.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(q => q.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(q => q.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(q => q.PhoneNo)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
