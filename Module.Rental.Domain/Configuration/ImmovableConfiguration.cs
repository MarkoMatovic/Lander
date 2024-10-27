using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Rental.Domain.Aggregates;

namespace Module.Rental.Domain.Configuration;

public class ImmovableConfiguration : IEntityTypeConfiguration<Immovable>
{
    public void Configure(EntityTypeBuilder<Immovable> entity)
    {
        entity.HasKey(e => e.ImmovableId).HasName("PK__Immovabl__012EFF4C5978BAF3");

        entity.Property(e => e.ImmovableId).ValueGeneratedOnAdd();
        entity.Property(e => e.AvailableFrom).HasColumnType("datetime");
        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        entity.Property(e => e.Title).HasMaxLength(50);

       
    }
}
