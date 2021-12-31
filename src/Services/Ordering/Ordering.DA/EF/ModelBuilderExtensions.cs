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
            string paymentID = "61b6f8c78909657b658f6887";
            string deliveryID = "61b6f8cfbc9a67e61c8ddf2e";
            string customerID = "61cea2f375e10dd236f9de06";
            string orderID = "61b6f8e8a13fc9a1ba108bf3";
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentID = paymentID,
                    PaymentMethod = "",
                    CardName = "ABC",
                    CardNo = "1221313",
                    Expiration = new DateTime(2022, 2, 2),
                    CVV = "123",
                    CustomerID = customerID
                }
            );

            modelBuilder.Entity<Delivery>().HasData(

                    new Delivery
                    {
                        DeliveryID = deliveryID,
                        FirstNameReceiver = "Viet",
                        LastNameReceiver = "Lam",
                        Address = "số 1 Võ Văn Ngân",
                        PhoneNo = "0944329423",
                        Email = "181330@gmail.com",
                        CustomerID = customerID
                    }
            );

            modelBuilder.Entity<Order>().HasData(
                    new Order
                    {
                        OrderID = orderID,
                        OrderDate = new DateTime(2021, 11, 5),
                        ConfirmDate = null,
                        TotalAmount = 100000,
                        Status = null,
                        StaffID = null,
                        CustomerID = customerID,
                        PaymentID = paymentID,
                        DeliveryID = deliveryID,
                        IsDelete = false,
                        CustomerName = "Viet"
                    }
                );

            modelBuilder.Entity<OrderDetail>().HasData(
                  new OrderDetail
                  {
                      OrderDetailID = Guid.NewGuid().ToString(),
                      OrderID = orderID,
                      Quantity = 1,
                      VAT = 0.1,
                      SalePrice = 50000,
                      ProductName = "Itel 33",
                      IMEI = "312312321312"
                  },
                   new OrderDetail
                   {
                       OrderDetailID = Guid.NewGuid().ToString(),
                       OrderID = orderID,
                       Quantity = 1,
                       VAT = 0.1,
                       SalePrice = 50000,
                       ProductName = "Tai nghe Sony",
                       IMEI = null

                   }
              );

        }
    }
}
