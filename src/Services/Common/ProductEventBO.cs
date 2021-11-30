using System.Collections.Generic;

namespace Common
{
    public class ProductEventBO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
    }
}