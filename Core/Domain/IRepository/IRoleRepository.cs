using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RolesAggregate;

namespace LandLander.Core.Domain.IRepository;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetAsync(Guid roleGuid);
}
