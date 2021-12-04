using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class OrderModel
    {
        public string OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public double TotalAmount { get; set; }
        public int? Status { get; set; }
        public double SalePrice { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int Gender { get; set; }//0: nữ, 1: nam
        public string CustomerPhone { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
        public PaymentModel PaymentInfo { get; set; }
        public DeliveryModel DeliveryInfo { get; set; }
    }
}
