using LandLander.Core.Domain.Aggregates.RentalAggregate;
using LandLander.Core.Domain.Aggregates.RentalConfiguration;
using LandLander.Core.Domain.Aggregates.RentalsAggregate;
using LandLander.Core.Domain.Aggregates.RolesAggregate;
using LandLander.Core.Infrastructure.Configuration.RentalConfiguration;
using LandLander.Core.Infrastructure.Configuration.RoleConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LandLander.Core.Infrastructure.Entity;

public class RentalbaseContext : DbContext
{
    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerPermission> CustomerPermissions { get; set; }

    public virtual DbSet<Immovable> Immovables { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public RentalbaseContext(DbContextOptions<RentalbaseContext> options)
       : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ImmovableConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new OfferConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerPermissionConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionsConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionsConfiguration());
        modelBuilder.ApplyConfiguration(new RolesConfiguration());
    }
}
