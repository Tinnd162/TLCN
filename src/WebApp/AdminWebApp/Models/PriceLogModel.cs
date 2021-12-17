using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebApp.Models
{
    public class PriceLogModel
    {
        public string Id { get; set; }
        public decimal SalePrice { get; set; }
        public string UserUpdate { get; set; }
    }
}
