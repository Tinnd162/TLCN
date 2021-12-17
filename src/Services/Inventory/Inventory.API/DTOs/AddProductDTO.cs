using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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
        public InfoDTO BrandDTO { get; set; }
        public InfoDTO CategoryDTO { get; set; }
        public PriceLogDTO PriceLogDTO { get; set; }
        public IFormFile Image { get; set; }
        public string UserUpdate { get; set; }
    }
}