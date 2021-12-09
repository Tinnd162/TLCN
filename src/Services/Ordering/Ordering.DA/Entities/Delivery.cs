using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.DA.Entities
{
    public class Delivery
    {
        public string DeliveryID { get; set; }
        public string FirstNameReceiver { get; set; }
        public string LastNameReceiver { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string CustomerID { get; set; }
        public List<Order> Orders { get; set; }
    }
}
