using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class InventoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
    }
}
