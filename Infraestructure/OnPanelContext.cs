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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
