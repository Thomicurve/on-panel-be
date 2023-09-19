using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infraestructure;

public class CostConfig : IEntityTypeConfiguration<Cost>
{
    public void Configure(EntityTypeBuilder<Cost> builder)
    {
        builder.ToTable("cost");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Property(p => p.CostTypeId).IsRequired();
        builder.Property(p => p.UserId).IsRequired();

        builder
            .HasOne(p => p.CostType)
            .WithMany()
            .HasForeignKey(p => p.CostTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
