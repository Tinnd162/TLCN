using System.Collections.Generic;
using System.Linq;

namespace AspnetRunBasics.Models
{
    public class BasketModel
    {
        public string Username { get; set; }
        public List<SODetailModel> Items { get; set; } = new List<SODetailModel>();
        public decimal TotalAmount
        {
            get
            {
                decimal totalPrice = 0;
                totalPrice = Items.Sum(x => x.SalePrice * x.Quantity);
                return totalPrice;
            }
        }
    }
}