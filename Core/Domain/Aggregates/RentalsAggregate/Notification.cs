﻿using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RentalConfiguration;

namespace LandLander.Core.Domain.Aggregates.RentalsAggregate;

public class Notification : IAggregateRoot
{
    public int NotificationId { get; set; }

    public Guid NotificationGuid { get; set; }

    public string NotificationType { get; set; } = null!;

    public string NotificationBody { get; set; } = null!;

    public bool IsRead { get; set; }

    public int UserId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Customer User { get; set; } = null!;
}
