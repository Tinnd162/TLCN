using System.Collections.Generic;

namespace Inventory.API.DTOs
{
    public class BrandWithCategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<InfoDTO> lstBrandDTO { get; set; }
    }
}