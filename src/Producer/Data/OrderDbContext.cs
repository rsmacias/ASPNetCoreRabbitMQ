#nullable disable
using Microsoft.EntityFrameworkCore;

namespace Producer.Data {
    public class OrderDbContext : DbContext, IOrderDbContext {

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) {
            
        }

        public DbSet<Order> Orders { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

    }
}