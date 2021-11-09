using Microsoft.EntityFrameworkCore;
using Ordering.BO;
using Ordering.DA.EF;
using Ordering.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA
{
    public class OrderDA : IOrderDA
    {

        public readonly OrderDbContext _context;
        public OrderDA(OrderDbContext context)
        {
            _context = context;
        }
        public Task CreateOrder(ref OrderBO Order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(string OrderID)
        {
            throw new NotImplementedException();
        }

        public Task<OrderBO> GetOrderByID(string OrderID)
        {
            var order =  _context.Orders.Where(x => x.OrderID.ToString() == OrderID).FirstOrDefault();
            if(order != null)
            {
                var orderBO = new OrderBO()
                {
                    OrderID = order.OrderID,
                    TotalAmount = order.TotalAmount
                };
                //foreach (var orderDetail in order.OrderDetails.ToList())
                //{
                //    orderBO.OrderDetails.Add(new OrderDetailBO
                //    {
                //        OrderDetailID = orderDetail.OrderDetailID,
                //        ProductName = orderDetail.ProductName
                //    });
                //}
                return Task.FromResult(orderBO);
            }
            return null;
        }

        public Task<OrderBO> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
