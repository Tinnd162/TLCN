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
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Deivery").HasKey(x => x.DeliveryID);
            builder.Property(x => x.FirstNameReceiver).IsRequired();
            builder.Property(x => x.PhoneNo).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.CustomerID).IsRequired();
            
        }
    }
}
