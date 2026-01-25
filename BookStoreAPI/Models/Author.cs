using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Utilities.Models;

namespace BookStoreAPI.Models
{
    public class Author : IMongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
