using Microsoft.EntityFrameworkCore.Storage;

namespace LandLander.Services.Helpers;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveEntities(CancellationToken cancellationToken);
    Task<IDbContextTransaction?> BeginTransaction();
    Task CommitTransaction(IDbContextTransaction? transaction);
    void RollBackTrasaction();
}
