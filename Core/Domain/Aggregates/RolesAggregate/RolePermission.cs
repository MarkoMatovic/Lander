using LandLander.Core.Common;

namespace LandLander.Core.Domain.Aggregates.RolesAggregate;

public class RolePermission : IAggregateRoot
{
    public int RolePermissionId { get; set; }

    public Guid RolePermissionGuid { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid? ModifiedByGuid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
