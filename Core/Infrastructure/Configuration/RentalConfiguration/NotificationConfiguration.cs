using LandLander.Core.Domain.Aggregates.RentalsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLander.Core.Infrastructure.Configuration.RentalConfiguration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> entity)
    {
        entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E12C6032B32");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.NotificationType).HasMaxLength(100);

        entity.HasOne(d => d.User).WithMany(p => p.Notifications)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Notificat__UserI__4D94879B");
    }
}
