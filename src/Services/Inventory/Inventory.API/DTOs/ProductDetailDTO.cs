using System;

namespace Inventory.API.DTOs
{
    public class ProductDetailDTO
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public int IsUpdate { get; set; }
        public int IsStatus { get; set; }
        public int IsDiscontinued { get; set; }
        public int IsDelete { get; set; }
    }
}