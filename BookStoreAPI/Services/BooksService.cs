using BookStoreAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Utilities.Wrappers;

namespace BookStoreAPI.Services
{

    public class BooksService : MongoService<Book>, IBooksService
    {
        public BooksService(IOptions<BookStoreDatabaseOptions> options) : base(options.Value.ConnectionString, options.Value.DatabaseName,"Books")
        {

        }
    }
}
