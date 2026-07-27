namespace Domain.Primitives;

public abstract class AuditableEntityBase<TId> : Entity<TId>
where TId : struct, IEquatable<TId>
{
    public DateTime? CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    //public byte[]? RowVersion { get; set; }
    public override void SoftDelete()
    {
        DeletedAt = DateTime.Now;
        base.SoftDelete();
    }
}

