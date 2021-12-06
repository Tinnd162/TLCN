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

        public OrderBO GetOrderByID(string strCustomerID, string strSaleOrderID, ref string strErrorMessage)
        {
            try
            {
                OrderBO objSaleOrderBO = null;
                var objSaleOrder = _context.Orders.Where(x => x.OrderID == strSaleOrderID && x.CustomerID == strCustomerID).Include(x => x.OrderDetails).FirstOrDefault();
                if (objSaleOrder != null)
                {
                    objSaleOrderBO = new OrderBO()
                    {
                        OrderID = objSaleOrder.OrderID,
                        OrderDate = objSaleOrder.OrderDate,
                        ConfirmDate = objSaleOrder.ConfirmDate,
                        Status = objSaleOrder.Status,
                        TotalAmount = objSaleOrder.TotalAmount,
                        OrderDetails = objSaleOrder.OrderDetails.Select(
                            od => new OrderDetailBO
                            {
                                OrderDetailID = od.OrderDetailID,
                                ProductName = od.ProductName,
                                IMEI = od.IMEI,
                                Quantity = od.Quantity,
                                VAT = od.VAT,
                                SalePrice = od.SalePrice
                            }).ToList()
                    };
                }
                if (objSaleOrderBO == null)
                    strErrorMessage = "Không tìm thấy đơn hàng theo yêu cầu!";
                return objSaleOrderBO;
            }
            catch(Exception objEx)
            {
                strErrorMessage = $"Lỗi lấy thông tin của đơn hàng {strSaleOrderID}!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return null;
            }
        }



        public List<OrderBO> GetSaleOrderList(string strCustomerID, ref string strErrorMessage)
        {
            try
            {
                var lstSaleOrderBO = _context.Orders.Where(x => x.CustomerID == strCustomerID)
                                                    .Include(x => x.OrderDetails)
                                                    .Select(x => new OrderBO
                                                    {
                                                        OrderID = x.OrderID,
                                                        OrderDate = x.OrderDate,
                                                        ConfirmDate = x.ConfirmDate,
                                                        Status = x.Status,
                                                        TotalAmount = x.TotalAmount,
                                                        OrderDetails = x.OrderDetails.Select(od => new OrderDetailBO
                                                        {
                                                            OrderDetailID = od.OrderDetailID,
                                                            ProductName = od.ProductName,
                                                            IMEI = od.IMEI,
                                                            Quantity = od.Quantity,
                                                            VAT = od.VAT,
                                                            SalePrice = od.SalePrice
                                                        }).ToList()
                                                    })
                                                    .OrderByDescending(x => x.OrderDate)
                                                    .ToList();
                if(lstSaleOrderBO == null || lstSaleOrderBO.Count == 0)
                    strErrorMessage = "Không tìm thấy đơn hàng theo yêu cầu!";
                return lstSaleOrderBO;
            }
            catch(Exception objEx)
            {
                strErrorMessage = $"Lỗi lấy danh sách đơn hàng của khách hàng!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return null;
            }
        }

        public List<PaymentInfo> GetPaymentInfos(string strCustomerID, ref string strErrorMessage)
        {
            try
            {
                var lstPaymentInfos = _context.Payments.Where(x => x.CustomerID == strCustomerID)
                                                        .Select(x => new PaymentInfo
                                                        {
                                                            PaymentID = x.PaymentID,
                                                            PaymentMethod = x.PaymentMethod,
                                                            CardName = x.CardName,
                                                            CardNo = x.CardNo,
                                                            CVV = x.CVV,
                                                            Expiration = x.Expiration,
                                                        }).Distinct().ToList();
                if (lstPaymentInfos != null && lstPaymentInfos.Count > 0)
                    return lstPaymentInfos;
                strErrorMessage = "Không tìm thấy thông tin thanh toán của khách hàng!";
                return null;
            }
            catch (Exception objEx)
            {
                strErrorMessage = "Lỗi lấy thông tin thanh toán của khách hàng!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return null;
            }
        }

        public List<DeliveryInfo> GetDeliveryInfos(string strCustomerID, ref string strErrorMessage)
        {
            try
            {
                var lstDeliveryInfos = _context.Deliveries.Where(x => x.CustomerID == strCustomerID)
                                                          .Select(x => new DeliveryInfo
                                                          {
                                                              DeliveryID = x.DeliveryID,
                                                              Address = x.Address,
                                                              PhoneNo = x.PhoneNo,
                                                              Email = x.Email,
                                                              FirstNameReceiver = x.FirstNameReceiver,
                                                              LastNameReceiver = x.LastNameReceiver
                                                          }).Distinct().ToList();
                if (lstDeliveryInfos != null && lstDeliveryInfos.Count > 0)
                    return lstDeliveryInfos;
                strErrorMessage = "Không tìm thấy thông tin giao hàng của khách hàng!";
                return null;
            }
            catch(Exception objEx)
            {
                strErrorMessage = "Lỗi lấy thông tin giao hàng của khách hàng!";
                Console.WriteLine(strErrorMessage + ", Message detail: " + objEx.ToString());
                return null;
            }
        }
    }
}
