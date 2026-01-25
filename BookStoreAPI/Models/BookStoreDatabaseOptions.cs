namespace BookStoreAPI.Models
{
    public class BookStoreDatabaseOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
