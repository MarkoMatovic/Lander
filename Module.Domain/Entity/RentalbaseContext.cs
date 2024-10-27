using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Module.Domain.Aggregates;
using Module.Domain.Configuration;

namespace Module.Domain.Entity;

public class RentalbaseContext : DbContext
{
    private IDbContextTransaction? _transaction;
    public virtual DbSet<Customer> Customers { get; set; }

    public RentalbaseContext(DbContextOptions<RentalbaseContext> options)
     : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
    public async Task<int> SaveEntities(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken: cancellationToken);
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
