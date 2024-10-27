using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Rental.Domain.Aggregates;

namespace Module.Message.Domain.Configuration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> entity)
    {
        entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E12C6032B32");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.NotificationType).HasMaxLength(100);

       
    }
}
