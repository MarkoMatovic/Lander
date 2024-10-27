using LandLander.Core.Common;
using Module.Domain.Aggregates;

namespace Module.Roles.Domain.Aggregates;

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
