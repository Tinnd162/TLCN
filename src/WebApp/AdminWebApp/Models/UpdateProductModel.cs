using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebApp.Models
{
    public class UpdateProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public int Quantity { get; set; }
        public bool IsDiscontinued { get; set; }
        public bool IsStatus { get; set; }
        public BrandInfoModel BrandDTO { get; set; } = new BrandInfoModel();
        public BrandInfoModel CategoryDTO { get; set; } = new BrandInfoModel();
        public PriceLogModel PriceLogDTO { get; set; }
        public string UserUpdate { get; set; }

    }
}
