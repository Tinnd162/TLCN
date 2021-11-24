using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Entities
{
    [Table("Category")]
    public class Category
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}