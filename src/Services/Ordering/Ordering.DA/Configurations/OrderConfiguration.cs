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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("SaleOrder").HasKey(x => x.OrderID);
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.CustomerID).IsRequired(); 
            builder.Property(x => x.PaymentID).IsRequired();
            builder.Property(x => x.DeliveryID).IsRequired();
            builder.Property(x => x.CustomerName).IsRequired();
            builder.HasOne(x => x.Payment)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.PaymentID);
            builder.HasOne(x => x.Delivery)
                  .WithMany(x => x.Orders)
                  .HasForeignKey(x => x.DeliveryID);
            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Orders)
                .HasForeignKey(x => x.OrderID);


        }
    }
}
