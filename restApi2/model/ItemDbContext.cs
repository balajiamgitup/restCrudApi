using Microsoft.EntityFrameworkCore;

namespace restApi2.model
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options):base(options)
        {

        }

        public DbSet<Item> items { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderItems> orderItems { get; set; }
    }
}
