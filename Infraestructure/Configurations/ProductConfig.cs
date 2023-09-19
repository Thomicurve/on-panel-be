using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infraestructure;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.Stock).IsRequired();
        builder.Property(p => p.ImageUrl).IsRequired(false);
        builder.Property(p => p.UserId).IsRequired();

        builder
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
