using BookStoreAPI.Models;
using Microsoft.Extensions.Options;
using Utilities.Wrappers;

namespace BookStoreAPI.Services
{
    public class CategoryService : MongoService<Category>, ICategoryService
    {
        public CategoryService(IOptions<BookStoreDatabaseOptions> options) : base(options.Value.ConnectionString, options.Value.DatabaseName,"Categories")
        {
        }
    }
}
