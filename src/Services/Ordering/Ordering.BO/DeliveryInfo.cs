using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BO
{
    public class DeliveryInfo
    {
        public string DeliveryID { get; set; }
        public string FirstNameReceiver { get; set; }
        public string LastNameReceiver { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string CustomerID { get; set; }
        [JsonProperty(PropertyName = "IsExist")]
        public bool cus_IsExist { get; set; }
    }
}
