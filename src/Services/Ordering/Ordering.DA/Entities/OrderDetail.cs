using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.Entities
{
    public class OrderDetail
    {
        public string OrderDetailID { get; set; }
        public string OrderID { get; set; }
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public string IMEI { get; set; }
        public int Quantity { get; set; }
        public double VAT { get; set; }
        public double SalePrice { get; set; }
        public string Color { get; set; }
        public Order Orders { get; set; }
    }
}
