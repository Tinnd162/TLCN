using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment").HasKey(x => x.PaymentID);
            builder.Property(x => x.PaymentMethod).IsRequired();
            builder.Property(x => x.CardName).IsRequired();
            builder.Property(x => x.CardNo).IsRequired();
            builder.Property(x => x.CVV).IsRequired();
            builder.Property(x => x.Expiration).IsRequired();
        }
    }
}
