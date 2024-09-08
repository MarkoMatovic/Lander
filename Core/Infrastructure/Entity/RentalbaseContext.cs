using LandLander.Core.Domain.Aggregates.RentalAggregate;
using LandLander.Core.Domain.Aggregates.RentalConfiguration;
using LandLander.Core.Domain.Aggregates.RentalsAggregate;
using LandLander.Core.Domain.Aggregates.RolesAggregate;
using LandLander.Core.Infrastructure.Configuration.RentalConfiguration;
using LandLander.Core.Infrastructure.Configuration.RoleConfiguration;
using LandLander.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace LandLander.Core.Infrastructure.Entity;

public class RentalbaseContext : DbContext, IUnitOfWork
{
    private IDbContextTransaction? _transaction;
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

    public async Task<int> SaveEntities(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task<IDbContextTransaction?> BeginTransaction()
    {
        if (_transaction is not null) return null;
        _transaction = await Database.BeginTransactionAsync(isolationLevel: IsolationLevel.ReadCommitted);
        return _transaction;
    }

    public async Task CommitTransaction(IDbContextTransaction? transaction)
    {
        try
        {
            await SaveChangesAsync();
            await transaction?.CommitAsync();
        }
        catch
        {
            RollBackTrasaction();
            throw;
        }
        finally
        {
            if (_transaction is not null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }

    public void RollBackTrasaction()
    {
        try
        {
            _transaction?.Rollback();
        }
        finally
        {
            if ( _transaction is not null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
