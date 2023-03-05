using Microsoft.EntityFrameworkCore;

namespace Producer.Data {
    public interface IOrderDbContext {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync();
    }
}