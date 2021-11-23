using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Entities
{
    [Table("Color")]
    public class Color
    {
        public string Id { get; set; }
        public string ColorName { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}