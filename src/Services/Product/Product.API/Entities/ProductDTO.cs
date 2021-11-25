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
        public string Color { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public string CategoryId { get; set; }
        public string CategotyName { get; set; }
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
    }
}