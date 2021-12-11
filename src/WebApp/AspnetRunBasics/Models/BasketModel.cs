using System.Collections.Generic;

namespace AspnetRunBasics.Models
{
    public class BasketModel
    {
        public string Username { get; set; }
        public decimal TotalAmount { get; set; }
        public List<SODetailModel> Items { get; set; } = new List<SODetailModel>();
    }
}