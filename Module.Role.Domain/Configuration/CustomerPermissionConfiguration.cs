using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Roles.Domain.Aggregates;

namespace Module.Roles.Domain.Configuration;

public class CustomerPermissionConfiguration : IEntityTypeConfiguration<CustomerPermission>
{
    public void Configure(EntityTypeBuilder<CustomerPermission> entity)
    {
        entity.HasKey(e => e.CustomerPermissionId).HasName("PK__Customer__3E4483A347FD4717");

        entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

        entity.HasOne(d => d.Permission)
              .WithMany(p => p.CustomerPermissions)
              .HasForeignKey(d => d.PermissionId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__CustomerP__Permi__571DF1D5");

        
    }
}
