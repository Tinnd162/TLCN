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

        public async Task<OrderBO> GetOrderByID(string strSaleOrderID)
        {
            try
            {
                var objSaleOrder = _context.Orders.Where(x => x.OrderID.ToString() == strSaleOrderID).FirstOrDefault();
                if (objSaleOrder != null)
                {
                    var objSaleOrderBO = new OrderBO()
                    {
                        OrderID = objSaleOrder.OrderID,
                        OrderDate = objSaleOrder.OrderDate,
                        ConfirmDate = objSaleOrder.ConfirmDate,
                        Status = objSaleOrder.Status,
                        TotalAmount = objSaleOrder.TotalAmount
                    };
                    var objSaleOrderDetail = _context.OrderDetails.Where(x => x.OrderID.ToString() == strSaleOrderID)
                                                                  .Select(x => new OrderDetailBO
                                                                  {
                                                                      OrderDetailID = x.OrderDetailID,
                                                                      ProductName = x.ProductName,
                                                                      IMEI = x.IMEI,
                                                                      Quantity = x.Quantity,
                                                                      VAT = x.VAT,
                                                                      SalePrice = x.SalePrice
                                                                  }).ToList();
                    if (objSaleOrderDetail != null && objSaleOrderDetail.Count > 0)
                    {
                        objSaleOrderBO.OrderDetails = objSaleOrderDetail;
                    }
                    return await Task.FromResult(objSaleOrderBO);
                }
            }
            catch(Exception objEx)
            {
                throw objEx;
            }
            return null;
        }

        public Task<OrderBO> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
