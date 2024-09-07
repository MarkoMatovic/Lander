﻿using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RentalAggregate;
using System;
using System.Collections.Generic;

namespace LandLander.Core.Domain.Aggregates.RentalConfiguration;

public class Message : IAggregateRoot
{
    public int MessageId { get; set; }

    public Guid MessageGuid { get; set; }

    public string MessageContent { get; set; } = null!;

    public int SenderId { get; set; }

    public int ReciverId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid ModifiedByGuid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Immovable Reciver { get; set; } = null!;

    public virtual Customer Sender { get; set; } = null!;
}
