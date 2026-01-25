using BookStoreAPI.Models;
using Utilities.Wrappers;

namespace BookStoreAPI.Services
{
    public interface IBooksService : IMongoService<Book>
    {
    }
}
