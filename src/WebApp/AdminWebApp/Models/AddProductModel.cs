using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebApp.Models
{
    public class AddProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public BrandInfoModel BrandDTO { get; set; }
        public BrandInfoModel CategoryDTO { get; set; }
        public PriceLogModel PriceLogDTO { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
        public string UserUpdate { get; set; }
    }
}
