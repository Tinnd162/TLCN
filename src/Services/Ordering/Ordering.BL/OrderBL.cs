using Ordering.BL.Interfaces;
using Ordering.BO;
using Ordering.DA;
using Ordering.DA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BL
{
    public class OrderBL : IOrderBL
    {
        public readonly OrderDbContext _context;
        public OrderBL(OrderDbContext context)
        {
            this._context = context;
        }

        public List<DeliveryInfo> GetDeliveryInfos(string strCustomerID, ref string strErrorMessage)
        {
            try
            {
                OrderDA objSalOrderDA = new OrderDA(_context);
                var lstObjSaleOrderBO = objSalOrderDA.GetDeliveryInfos(strCustomerID, ref strErrorMessage);
                return lstObjSaleOrderBO;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public OrderBO GetOrderByID(string strCustomerID, string strSaleOrderID, ref string strErrorMessage)
        {
            try
            {
                OrderDA objSalOrderDA = new OrderDA(_context);
                var objSaleOrderBO = objSalOrderDA.GetOrderByID(strCustomerID, strSaleOrderID, ref strErrorMessage);
                return objSaleOrderBO;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public List<PaymentInfo> GetPaymentInfos(string strCustomerID, ref string strErrorMessage)
        {
            try
            {
                OrderDA objSalOrderDA = new OrderDA(_context);
                var lstObjSaleOrderBO = objSalOrderDA.GetPaymentInfos(strCustomerID, ref strErrorMessage);
                return lstObjSaleOrderBO;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public List<OrderBO> GetSaleOrderList(string strCustomerID, ref string strErrorMessage)
        {
            try
            {
                OrderDA objSalOrderDA = new OrderDA(_context);
                var objSaleOrderBO = objSalOrderDA.GetSaleOrderList(strCustomerID, ref strErrorMessage);
                return objSaleOrderBO;
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public bool InsertSaleOrder(OrderBO objSaleOrderBO, ref string strErrorMessage)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                OrderDA objOrderDA = new OrderDA(_context);
                if (objSaleOrderBO.PaymentInfo != null && !objSaleOrderBO.PaymentInfo.cus_IsExist)
                {
                    if (!objOrderDA.InsertPaymentInfo(objSaleOrderBO.PaymentInfo, objSaleOrderBO.CustomerID, ref strErrorMessage))
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                if (objSaleOrderBO.DeliveryInfo != null && !objSaleOrderBO.DeliveryInfo.cus_IsExist)
                {
                    if (!objOrderDA.InsertDeliveryInfo(objSaleOrderBO.DeliveryInfo, objSaleOrderBO.CustomerID, ref strErrorMessage))
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                string strSaleOrderID = Guid.NewGuid().ToString();
                if (!objOrderDA.InsertSaleOrder(strSaleOrderID, objSaleOrderBO.CustomerID, objSaleOrderBO.PaymentInfo.PaymentID, objSaleOrderBO.DeliveryInfo.DeliveryID
                    , objSaleOrderBO.TotalAmount, objSaleOrderBO.CustomerName, objSaleOrderBO.CustomerAddress, objSaleOrderBO.Gender, objSaleOrderBO.CustomerPhone, ref strErrorMessage))
                {
                    transaction.Rollback();
                    return false;
                }

                if (objSaleOrderBO.OrderDetails != null && objSaleOrderBO.OrderDetails.Count > 0)
                {
                    if (!objOrderDA.InsertSaleOrderDetail(strSaleOrderID, objSaleOrderBO.OrderDetails, ref strErrorMessage))
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                objSaleOrderBO.OrderID = strSaleOrderID;
                transaction.Commit();
                return true;
            }
            catch (Exception objEx)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
