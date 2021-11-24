using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Entities
{
    [Table("Brand")]
    public class Brand
    {
        public string Id { get; set; }
        public string BrandName { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}