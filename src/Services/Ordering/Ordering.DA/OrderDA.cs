using Microsoft.EntityFrameworkCore;
using Ordering.BO;
using Ordering.DA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA
{
    public class OrderDA
    {

        public readonly OrderDbContext _context;
        public OrderDA(OrderDbContext context)
        {
            _context = context;
        }
        public bool InsertSaleOrder(string strSaleOrderID, string strCustomerID, string strPaymentID, string strDeliveryID, double douTotalAmount, 
            string strCustomerName, string strCustomerAddress, int intGender, string strCustomerPhone, ref string strErrorMessage)
        {
            try
            {
                _context.Orders.Add(new Entities.Order
                {
                    OrderID = strSaleOrderID,
                    OrderDate = DateTime.Now,
                    TotalAmount = douTotalAmount,
                    CustomerID = strCustomerID,
                    PaymentID = strPaymentID,
                    DeliveryID = strDeliveryID,
                    CustomerName = strCustomerName,
                    CustomerAddress = strCustomerAddress,
                    Gender = intGender,
                    CustomerPhone = strCustomerPhone
                });
                _context.SaveChanges();
            }
            catch (Exception objEx)
            {
                strErrorMessage = "Lỗi tạo đơn hàng!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                strSaleOrderID = string.Empty;
                return false;
            }
            return true;
        }

        public bool InsertSaleOrderDetail(string strSaleOrderID, List<OrderDetailBO> lstSaleOrderDetailBO, ref string strErrorMessage)
        {
            try
            {
                string strSaleOrderDetailID = string.Empty;
                foreach(var objSODetail in lstSaleOrderDetailBO)
                {
                    strSaleOrderDetailID = Guid.NewGuid().ToString();
                    _context.OrderDetails.Add(new Entities.OrderDetail
                    {
                        OrderID = strSaleOrderID,
                        OrderDetailID  = strSaleOrderDetailID,
                        ProductID = objSODetail.ProductID,
                        ProductName = objSODetail.ProductName,
                        IMEI = objSODetail.IMEI,
                        Quantity = objSODetail.Quantity,
                        SalePrice = objSODetail.SalePrice,
                        VAT = objSODetail.VAT
                    });
                }
                _context.SaveChanges();
            }
            catch (Exception objEx)
            {
                strErrorMessage = "Lỗi tạo chi tiết đơn hàng!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return false;
            }
            return true;
        }

        public bool InsertPaymentInfo(PaymentInfo objPaymentInfo, ref string strErrorMessage)
        {
            try
            {
                string strPaymentID = Guid.NewGuid().ToString();
                _context.Payments.Add(new Entities.Payment
                {
                    PaymentID = strPaymentID,
                    PaymentMethod = objPaymentInfo.PaymentMethod,
                    CardName = objPaymentInfo.CardName,
                    CardNo = objPaymentInfo.CardNo,
                    Expiration = objPaymentInfo.Expiration,
                    CVV = objPaymentInfo.CardNo
                });
                objPaymentInfo.PaymentID = strPaymentID;
                _context.SaveChanges();
            }
            catch (Exception objEx)
            {
                strErrorMessage = $"Lỗi thêm thông tin thanh toán cho đơn hàng!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return false;
            }
            return true;
        }

        public bool InsertDeliveryInfo(DeliveryInfo objDeliveryInfo, ref string strErrorMessage)
        {
            try
            {
                string strDeliveryID = Guid.NewGuid().ToString();
                _context.Deliveries.Add(new Entities.Delivery
                {
                    DeliveryID = strDeliveryID,
                    FirstNameReceiver = objDeliveryInfo.FirstNameReceiver,
                    LastNameReceiver = objDeliveryInfo.LastNameReceiver,
                    Address = objDeliveryInfo.Address,
                    PhoneNo = objDeliveryInfo.PhoneNo,
                    Email = objDeliveryInfo.Email,
                    CustomerID = objDeliveryInfo.CustomerID
                });
                objDeliveryInfo.DeliveryID = strDeliveryID;
                _context.SaveChanges();
            }
            catch (Exception objEx)
            {
                strErrorMessage = $"Lỗi thêm thông tin giao hàng cho đơn hàng!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return false;
            }
            return true;
        }

        public Task<bool> DeleteOrder(string OrderID)
        {
            throw new NotImplementedException();
        }

        public OrderBO GetOrderByID(string strSaleOrderID, ref string strErrorMessage)
        {
            try
            {
                OrderBO objSaleOrderBO = null;
                var objSaleOrder = _context.Orders.Where(x => x.OrderID == strSaleOrderID).FirstOrDefault();
                if (objSaleOrder != null)
                {
                    objSaleOrderBO = new OrderBO()
                    {
                        OrderID = objSaleOrder.OrderID,
                        OrderDate = objSaleOrder.OrderDate,
                        ConfirmDate = objSaleOrder.ConfirmDate,
                        Status = objSaleOrder.Status,
                        TotalAmount = objSaleOrder.TotalAmount
                    };
                    var objSaleOrderDetail = _context.OrderDetails.Where(x => x.OrderID == strSaleOrderID)
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
                }
                return objSaleOrderBO;
            }
            catch(Exception objEx)
            {
                strErrorMessage = $"Lỗi lấy thông tin của đơn hàng {strSaleOrderID}!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return null;
            }
        }

        public Task<OrderBO> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
