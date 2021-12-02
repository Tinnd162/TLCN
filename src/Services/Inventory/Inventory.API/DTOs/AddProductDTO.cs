using System;
using System.Collections.Generic;

namespace Inventory.API.DTOs
{
    public class AddProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDiscontinued { get; set; } = false;
        public bool IsStatus { get; set; } = false;
        public InfoDTO BrandDTO { get; set; }
        public InfoDTO CategoryDTO { get; set; }
        public PriceLogDTO PriceLogDTO { get; set; }
        public ConfigurationProductDTO ConfigurationProductDTO { get; set; }
        public InfoDTO SupplierDTO { get; set; }
        public List<InfoDTO> lstColor { get; set; }
    }
}