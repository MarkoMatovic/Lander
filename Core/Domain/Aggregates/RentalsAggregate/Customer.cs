﻿using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RentalAggregate;
using LandLander.Core.Domain.Aggregates.RentalsAggregate;
using LandLander.Core.Domain.Aggregates.RolesAggregate;

namespace LandLander.Core.Domain.Aggregates.RentalConfiguration;

public class Customer : IAggregateRoot
{
    public int UserId { get; set; }

    public Guid UserGuid { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public int RoleId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid ModifiedByGuid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<CustomerPermission> CustomerPermissions { get; set; } = new List<CustomerPermission>();

    public virtual Immovable? Immovable { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual Role Role { get; set; } = null!;
}