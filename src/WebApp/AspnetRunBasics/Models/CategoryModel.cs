using System;

namespace AspnetRunBasics.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int NumberOfSale { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
