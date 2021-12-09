using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BO
{
    public class OrderBO
    {
        public string OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public double TotalAmount { get; set; }
        public int? Status { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int Gender { get; set; }//0: nữ, 1: nam
        public string CustomerPhone { get; set; }
        public List<OrderDetailBO> OrderDetails { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
        public OrderBO()
        {
            OrderDetails = new List<OrderDetailBO>();
        }
    }
}
