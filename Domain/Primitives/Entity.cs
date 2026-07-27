namespace Domain.Primitives;
public abstract class Entity<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }

    public virtual void SoftDelete()
    {
        IsDeleted = true;
        //DeletedAt = DateTime.Now;
    }
}
