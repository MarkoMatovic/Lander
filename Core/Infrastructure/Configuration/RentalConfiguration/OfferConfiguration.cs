using LandLander.Core.Domain.Aggregates.RentalsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLander.Core.Infrastructure.Configuration.RentalConfiguration;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> entity)
    {
        entity.HasKey(e => e.OfferId).HasName("PK__Offers__8EBCF09145182A97");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

        entity.HasOne(d => d.Immovable).WithMany(p => p.Offers)
            .HasForeignKey(d => d.ImmovableId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Offers__Immovabl__46E78A0C");

        entity.HasOne(d => d.User).WithMany(p => p.Offers)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Offers__UserId__45F365D3");
    }
}
