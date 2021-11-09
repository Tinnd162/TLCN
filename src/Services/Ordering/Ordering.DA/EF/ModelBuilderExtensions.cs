using Microsoft.EntityFrameworkCore;
using Ordering.DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.EF
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid paymentID = Guid.NewGuid();
            Guid deliveryID = Guid.NewGuid();
            Guid customerID = Guid.NewGuid();
            Guid orderID = Guid.NewGuid();
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentID = paymentID,
                    PaymentMethod = "",
                    CardName = "ABC",
                    CardNo = "1221313",
                    Expiration = new DateTime(2022, 2, 2),
                    CVV = "123"
                }
            ) ;

            modelBuilder.Entity<Delivery>().HasData(

                    new Delivery
                    {
                        DeliveryID = deliveryID,
                        FirstNameReceiver = "Viet",
                        LastNameReceiver = "Lam",
                        Address ="123 ABC",
                        PhoneNo = "0123213",
                        Email = "asd@gmail.com",
                        CustomerID = customerID
                    }
            );

            modelBuilder.Entity<Order>().HasData(
                    new Order
                    {
                       OrderID = orderID,
                       OrderDate = new DateTime(2021,11,5),
                       ConfirmDate = null,
                       TotalAmount = 100000,
                       Status = null,
                       StaffID = new Guid(),
                       CustomerID = customerID,
                       PaymentID = paymentID,
                       DeliveryID = deliveryID,
                       IsDelete = false
                    }
                );

            modelBuilder.Entity<OrderDetail>().HasData(
                  new OrderDetail
                  {
                      OrderDetailID = Guid.NewGuid(),
                      OrderID = orderID,
                      Quantity = 1,
                      VAT = 0.1,
                      SalePrice = 50000,
                      ProductName = "Itel 33",
                      IMEI = "312312321312"
                  },
                   new OrderDetail
                   {
                       OrderDetailID = Guid.NewGuid(),
                       OrderID = orderID,
                       Quantity = 1,
                       VAT = 0.1,
                       SalePrice = 50000,
                       ProductName = "Tai nghe Sony",
                       IMEI = null

                   }
              ) ;

        }
    }
}
