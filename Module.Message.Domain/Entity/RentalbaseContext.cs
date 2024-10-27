using LandLander.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Module.Message.Domain.Configuration;
using Module.Rental.Domain.Aggregates;
using System.Data;

namespace Module.Message.Domain.Entity;

public class RentalbaseContext : DbContext, IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    public virtual DbSet<Messagge> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public RentalbaseContext(DbContextOptions<RentalbaseContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
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
            if (_transaction is not null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
