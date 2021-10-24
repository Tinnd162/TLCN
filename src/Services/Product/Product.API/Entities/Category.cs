using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.API.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CategoryName { get; set; }
    }
}