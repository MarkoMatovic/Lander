using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module.Domain.Aggregates;

namespace Module.Domain.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {

        entity.HasIndex(e => e.Email, "UQ__Customer__A9D105341A520F0D").IsUnique();
        entity.Property(e => e.Email).HasMaxLength(50);
        entity.Property(e => e.PasswordHash).HasMaxLength(255);
        entity.Property(e => e.PasswordSalt).HasMaxLength(255);
        entity.Property(e => e.UserName).HasMaxLength(50);

        entity.HasOne(d => d.Role).WithMany(p => p.Customers)
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Customers__RoleI__3F466844");
    }
}
