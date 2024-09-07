using LandLander.Core.Common;
using LandLander.Core.Domain.Aggregates.RentalAggregate;
using LandLander.Core.Domain.Aggregates.RentalConfiguration;

namespace LandLander.Core.Domain.Aggregates.RentalsAggregate;

public class Offer : IAggregateRoot
{
    public int OfferId { get; set; }

    public Guid OfferGuid { get; set; }

    public string OfferMessage { get; set; } = null!;

    public int UserId { get; set; }

    public int ImmovableId { get; set; }

    public bool IsDeleted { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid ModifiedByGuid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Immovable Immovable { get; set; } = null!;

    public virtual Customer User { get; set; } = null!;
}
