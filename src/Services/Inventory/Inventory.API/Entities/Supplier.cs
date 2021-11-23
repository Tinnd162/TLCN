using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Entities
{
    [Table("Supplier")]
    public class Supplier
    {
        public string Id { get; set; }
        public string SupplierName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}