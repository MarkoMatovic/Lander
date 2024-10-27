using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Roles.Domain.Aggregates;

namespace Module.Roles.Domain.Configuration;

public class PermissionsConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> entity)
    {
        entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2F8567AC37");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        entity.Property(e => e.PermissionName).HasMaxLength(100);
    }
}
