using System;
using System.Collections.Generic;
using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RentalConfiguration;

namespace LandLander.Core.Domain.Aggregates.RolesAggregate;

public class Role : IAggregateRoot
{
    public int RoleId { get; set; }

    public Guid RoleGuid { get; set; }

    public string RoleName { get; set; } = null!;

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid? ModifiedByGuid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
