using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.API.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BrandName { get; set; }
    }
}