using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFS.Domain.CommissionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFS.Infrastructure.Configuration
{
    public class CommissionConfiguration : IEntityTypeConfiguration<Commission>
    {
        public void Configure(EntityTypeBuilder<Commission> builder)
        {
            builder.HasKey(q => q.Id);
        }
    }
}
