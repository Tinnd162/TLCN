using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.Entities
{
    public class Payment
    {
        public string PaymentID { get; set; }
        public string CustomerID { get; set; }
        public string PaymentMethod { get; set; }
        public string CardName { get; set; }
        public string CardNo { get; set; }
        public DateTime? Expiration { get; set; }
        public string CVV { get; set; }

        public List<Order> Orders { get; set; }
    }
}
