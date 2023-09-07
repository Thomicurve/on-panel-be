using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infraestructure;

public class CostTypeConfig : IEntityTypeConfiguration<CostType>
{
    public void Configure(EntityTypeBuilder<CostType> builder)
    {
        builder.ToTable("cost_type");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired();
    }
}
