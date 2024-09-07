using LandLander.Core.Domain.Aggregates.RentalAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLander.Core.Infrastructure.Configuration.RentalConfiguration;

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

        entity.HasOne(d => d.ImmovableNavigation).WithOne(p => p.Immovable)
            .HasForeignKey<Immovable>(d => d.ImmovableId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Immovable__Immov__4316F928");
    }
}
