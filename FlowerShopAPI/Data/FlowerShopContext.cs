using Microsoft.EntityFrameworkCore;

namespace FlowerShopAPI.Data
{
    public class FlowerShopContext:DbContext
    {
        public FlowerShopContext(DbContextOptions<FlowerShopContext> options) : base(options)
        {
        }
    }
}
