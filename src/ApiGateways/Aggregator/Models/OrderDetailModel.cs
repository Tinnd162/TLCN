using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class OrderDetailModel
    {
        public string OrderDetailID { get; set; }
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public string IMEI { get; set; }
        public int Quantity { get; set; }
        public double VAT { get; set; }
        public double SalePrice { get; set; }
    }
}
