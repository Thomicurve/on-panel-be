using Microsoft.EntityFrameworkCore;
using Model;

namespace Infraestructure;

public class OnPanelContext : DbContext 
{
    public OnPanelContext(DbContextOptions<OnPanelContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Capital> Capitals { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<CostType> CostTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sell> Sells { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CapitalConfig().Configure(modelBuilder.Entity<Capital>());
        new UserConfig().Configure(modelBuilder.Entity<User>());
        new CostConfig().Configure(modelBuilder.Entity<Cost>());
        new CostTypeConfig().Configure(modelBuilder.Entity<CostType>());
        new ProductConfig().Configure(modelBuilder.Entity<Product>());
        new ProductSellConfig().Configure(modelBuilder.Entity<ProductSell>());
        new SellConfig().Configure(modelBuilder.Entity<Sell>());

        base.OnModelCreating(modelBuilder);
    }
}
