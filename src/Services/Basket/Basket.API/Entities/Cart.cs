using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class Cart
    {
        public Cart(string UserName)
        {
            this.UserName = UserName;
        }
        public string UserName { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
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
