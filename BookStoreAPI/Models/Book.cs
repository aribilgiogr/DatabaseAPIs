using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Utilities.Models;

namespace BookStoreAPI.Models
{
    public class Book : IMongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? CategoryId { get; set; }
        public string? AuthorId { get; set; }
    }
}
