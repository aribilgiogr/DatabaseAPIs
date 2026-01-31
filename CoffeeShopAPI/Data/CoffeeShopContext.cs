using Microsoft.EntityFrameworkCore;

namespace CoffeeShopAPI.Data
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options)
        {
        }
    }
}
