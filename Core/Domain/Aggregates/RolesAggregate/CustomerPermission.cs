using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RentalConfiguration;

namespace LandLander.Core.Domain.Aggregates.RolesAggregate;

public class CustomerPermission : IAggregateRoot
{
    public int CustomerPermissionId { get; set; }

    public Guid CustomerPermissionGuid { get; set; }

    public int UserId { get; set; }

    public int PermissionId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid? ModifiedByGuid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Customer User { get; set; } = null!;
}
