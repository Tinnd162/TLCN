using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.API.Entities
{
    public class ProductDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsUpdateQuantityAfterSO { get; set; }
        public int NumberOfSale { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}