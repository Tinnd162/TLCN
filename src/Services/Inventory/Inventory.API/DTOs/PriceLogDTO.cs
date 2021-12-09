using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.DTOs
{
    public class PriceLogDTO
    {
        public string Id { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal SalePrice { get; set; }
        public string UserUpdate { get; set; }
    }
}