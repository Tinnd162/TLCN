using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.Entities
{
    public class Order
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public double TotalAmount { get; set; }
        public int? Status { get; set; }
        public string StaffID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int Gender { get; set; }//0: nữ, 1: nam
        public string CustomerPhone { get; set; }
        public string PaymentID { get; set; }
        public string DeliveryID { get; set; }
        public bool IsDelete { get; set; }
        public Payment Payment { get; set; }
        public Delivery Delivery { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
