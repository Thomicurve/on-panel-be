using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infraestructure;

public class ProductSellConfig : IEntityTypeConfiguration<ProductSell>
{
    public void Configure(EntityTypeBuilder<ProductSell> builder)
    {
        builder.ToTable("product_sell");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.SellId).IsRequired();

        builder
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductSells)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(p => p.Sell)
            .WithMany(p => p.ProductSells)
            .HasForeignKey(p => p.SellId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
