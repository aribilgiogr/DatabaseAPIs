using MongoDB.Driver;
using Utilities.Models;

namespace Utilities.Wrappers
{
    public abstract class MongoService<T> : IMongoService<T> where T : class, IMongoEntity
    {
        protected readonly IMongoCollection<T> collection;

        protected MongoService(string connectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            collection = db.GetCollection<T>(collectionName);
        }

        public async Task DeleteAsync(string id) => await collection.DeleteOneAsync(x => x.Id == id);

        public async Task<IEnumerable<T>> GetAsync() => await collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(string id) => await collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(T newT) => await collection.InsertOneAsync(newT);

        public async Task ReplaceAsync(string id, T updatedT) => await collection.ReplaceOneAsync(x => x.Id == id, updatedT);
    }
}
