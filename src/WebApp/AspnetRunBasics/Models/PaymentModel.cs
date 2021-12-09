using System;

namespace AspnetRunBasics.Models
{
    public class PaymentModel
    {
        public string PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public string CardName { get; set; }
        public string CardNo { get; set; }
        public DateTime? Expiration { get; set; }
        public string CVV { get; set; }
        public bool cus_IsExist { get; set; }
    }
}