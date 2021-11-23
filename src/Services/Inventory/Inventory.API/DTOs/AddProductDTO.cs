using System;
using System.Collections.Generic;

namespace Inventory.API.DTOs
{
    public class AddProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public List<InfoDTO> lstColorDTO { get; set; }
        public string LinkImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDiscontinued { get; set; }
        public bool IsDelete { get; set; }
        public InfoDTO BrandDTO { get; set; }
        public InfoDTO CategoryDTO { get; set; }
        
    }
}