using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Roles.Domain.Aggregates;

namespace Module.Roles.Domain.Configuration;

public class RolesConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entity)
    {
        entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AC400F962");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        entity.Property(e => e.RoleName).HasMaxLength(50);
    }
}
