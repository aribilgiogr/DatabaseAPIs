using BookStoreAPI.Models;
using Microsoft.Extensions.Options;
using Utilities.Wrappers;

namespace BookStoreAPI.Services
{
    public class AuthorService : MongoService<Author>, IAuthorService
    {
        public AuthorService(IOptions<BookStoreDatabaseOptions> options) : base(options.Value.ConnectionString, options.Value.DatabaseName,"Authors")
        {
        }
    }
}
