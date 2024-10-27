using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Rental.Domain.Aggregates;

namespace Module.Message.Domain.Configuration;

public class MessageConfiguration : IEntityTypeConfiguration<Messagge>
{
    public void Configure(EntityTypeBuilder<Messagge> entity)
    {
        entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C0C9CACF93FA4");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

       
    }
}
