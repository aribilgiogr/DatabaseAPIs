using Utilities.Models;

namespace Utilities.Wrappers
{
    public interface IMongoService<T> where T : class, IMongoEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T?> GetAsync(string id);
        Task InsertAsync(T newT);
        Task ReplaceAsync(string id, T updatedT);
        Task DeleteAsync(string id);
    }
}
