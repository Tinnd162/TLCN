using Ordering.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BL.Interfaces
{
    public interface IOrderBL
    {
        public OrderBO GetOrderByID(string strCustomerID, string strSaleOrderID, ref string strErrorMessage);

        public bool InsertSaleOrder(OrderBO objSaleOrderBO, ref string strErrorMessage);

        public List<OrderBO> GetSaleOrderList(string strCustomerID, ref string strErrorMessage);
        public List<PaymentInfo> GetPaymentInfos(string strCustomerID, ref string strErrorMessage);
        public List<DeliveryInfo> GetDeliveryInfos(string strCustomerID, ref string strErrorMessage);
    }
}
