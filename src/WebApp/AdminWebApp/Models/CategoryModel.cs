using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebApp.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<BrandInfoModel> lstBrandDTO { get; set; }
    }
}
