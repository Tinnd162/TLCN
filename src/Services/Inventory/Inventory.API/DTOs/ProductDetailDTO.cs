using System;
using System.Collections.Generic;

namespace Inventory.API.DTOs
{
    public class ProductDetailDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDiscontinued { get; set; }
        public bool IsDelete { get; set; }
    }
}