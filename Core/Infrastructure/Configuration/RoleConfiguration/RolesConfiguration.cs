using LandLander.Core.Domain.Aggregates.RolesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandLander.Core.Infrastructure.Configuration.RoleConfiguration;

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
