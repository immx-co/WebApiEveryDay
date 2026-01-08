using Microsoft.EntityFrameworkCore;
using web.api.orders.Contracts;

namespace web.api.orders.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderLine> OrderLines { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(e =>
        {
            e.ToTable("Items");
            e.Property(x => x.Price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Order>(e =>
        {
            e.ToTable("Orders");
            e.Property(x => x.Price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<OrderLine>(e =>
        {
            e.ToTable("OrderLines");
            e.HasKey(x => new { x.OrderId, x.ItemId });
        });
    }
}
