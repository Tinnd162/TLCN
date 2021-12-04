using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BO
{
    public class PaymentInfo
    {
        public string PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public string CardName { get; set; }
        public string CardNo { get; set; }
        public DateTime? Expiration { get; set; }
        public string CVV { get; set; }
        [JsonProperty(PropertyName = "IsExist")]
        public bool cus_IsExist { get; set; }
    }
}
