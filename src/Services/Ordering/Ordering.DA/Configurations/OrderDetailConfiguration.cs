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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("SaleOrderDetail").HasKey(x => x.OrderDetailID);
            builder.Property(x => x.VAT).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.SalePrice).IsRequired();
            builder.Property(x => x.OrderID).IsRequired();

        }
    }
}
