using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.Entities
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public double TotalAmount { get; set; }
        public int? Status { get; set; }
        public Guid StaffID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid PaymentID { get; set; }
        public Guid DeliveryID { get; set; }
        public bool IsDelete { get; set; }
        
        public Payment Payment { get; set; }
        public Delivery Delivery { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
