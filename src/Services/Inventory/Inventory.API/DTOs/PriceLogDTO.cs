using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.DTOs
{
    public class PriceLogDTO
    {
        public string Id { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string UserUpdate { get; set; }
        public bool IsUpdate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}