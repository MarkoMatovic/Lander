using System;
using System.Collections.Generic;
using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RolesAggregate;

namespace LandLander.Core.Domain.Aggregates.RolesAggregate;
public class Permission : IAggregateRoot
{
    public int PermissionId { get; set; }

    public Guid PermissionGuid { get; set; }

    public string PermissionName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid? ModifiedByGuid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<CustomerPermission> CustomerPermissions { get; set; } = new List<CustomerPermission>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
