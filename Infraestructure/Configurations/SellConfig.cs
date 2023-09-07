using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infraestructure;

public class SellConfig : IEntityTypeConfiguration<Sell>
{
    public void Configure(EntityTypeBuilder<Sell> builder)
    {
        builder.ToTable("sell");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.TotalPrice).IsRequired();
    }
}
