using System.Collections.Generic;

namespace AspnetRunBasics.Models
{
    public class OrderResponseModel
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }

        // BillingAddress
        public DeliveryModel DeliveryInfo { get; set; }
        // Payment
        public PaymentModel PaymentInfo { get; set; }
        //OrderDetail
        public List<BasketItemModel> OrderDetails { get; set; }
    }
}
