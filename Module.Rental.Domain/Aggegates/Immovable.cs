using LandLander.Core.Common;
using Module.Domain.Aggregates;

namespace Module.Rental.Domain.Aggregates;

public class Immovable : IAggregateRoot
{
    public int ImmovableId { get; set; }

    public Guid ImmovableGuid { get; set; }

    public string Title { get; set; } = null!;

    public string Desciption { get; set; } = null!;

    public string AddressImm { get; set; } = null!;

    public string RentPrice { get; set; } = null!;

    public int Bedrooms { get; set; }

    public int? Bathrooms { get; set; }

    public bool IsFurnished { get; set; }

    public DateTime AvailableFrom { get; set; }

    public bool IsActive { get; set; }

    public int? UserId { get; set; }

    public Guid CreatedByGuid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid ModifiedByGuid { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Customer ImmovableNavigation { get; set; } = null!;

    public virtual ICollection<Messagge> Messages { get; set; } = new List<Messagge>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
