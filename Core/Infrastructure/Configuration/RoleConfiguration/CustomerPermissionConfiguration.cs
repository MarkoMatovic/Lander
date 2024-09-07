using LandLander.Core.Domain.Aggregates.RolesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLander.Core.Infrastructure.Configuration.RoleConfiguration;

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

        entity.HasOne(d => d.User).WithMany(p => p.CustomerPermissions)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__CustomerP__UserI__5629CD9C");
    }
}
