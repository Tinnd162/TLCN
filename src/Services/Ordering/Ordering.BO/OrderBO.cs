using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BO
{
    public class OrderBO
    {
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public double TotalAmount { get; set; }
        public int? Status { get; set; }
        public List<OrderDetailBO> OrderDetails { get; set; }
        public OrderBO()
        {
            OrderDetails = new List<OrderDetailBO>();
        }
    }
}
