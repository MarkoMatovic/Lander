namespace Module.Domain.Aggregates;

public class Customer
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

  //  public virtual ICollection<CustomerPermission> CustomerPermissions { get; set; } = new List<CustomerPermission>();

  //  public virtual Immovable? Immovable { get; set; }

  //  public virtual ICollection<Messagge> Messages { get; set; } = new List<Messagge>();

  //  public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

  //  public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

  //  public virtual Role Role { get; set; } = null!;


    public Customer(Guid userGuid, string userName, string email, string passwordHash, string passwordSalt, bool isDeleted, Guid createdByGuid, DateTime createdDate, Guid modifiedByGuid, DateTime modifiedDate)
    {
        UserGuid = userGuid;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        IsDeleted = isDeleted;
        CreatedByGuid = createdByGuid;
        CreatedDate = createdDate;
        ModifiedByGuid = modifiedByGuid;
        ModifiedDate = modifiedDate;

    }

    public void SetIsDeleted(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }

    public void SetModified(Guid modifiedByGuid, DateTime? modifiedDate)
    {
        ModifiedByGuid = modifiedByGuid;
        ModifiedDate = modifiedDate ?? DateTime.Now;
    }
}
