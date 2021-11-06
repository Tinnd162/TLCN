using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Entities
{
    [Table("PriceLog")]
    public class PriceLog
    {
        public string Id { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public string UserUpdate { get; set; }
        public string ProductId { get; set; }
        public DateTime UpdateDate { get; set; }
        public Product Product { get; set; }
    }
}