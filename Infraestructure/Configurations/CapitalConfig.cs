using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infraestructure;

public class CapitalConfig : IEntityTypeConfiguration<Capital>
{
    public void Configure(EntityTypeBuilder<Capital> builder)
    {
        builder.ToTable("capital");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.UserId).IsRequired();
        builder
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Capital>(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
