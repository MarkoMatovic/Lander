using LandLander.Core.Domain.Aggregates.RentalConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLander.Core.Infrastructure.Configuration.RentalConfiguration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> entity)
    {
        entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C0C9CACF93FA4");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

        entity.HasOne(d => d.Reciver).WithMany(p => p.Messages)
            .HasForeignKey(d => d.ReciverId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Messages__Recive__4AB81AF0");

        entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
            .HasForeignKey(d => d.SenderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Messages__Sender__49C3F6B7");
    }
}
