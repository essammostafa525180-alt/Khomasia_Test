using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Primitives;

public abstract class AggregateRootEntityBase<TId> : AuditableEntityBase<TId>, IAggregateRoot
where TId : struct, IEquatable<TId>
{
    private List<DomainEventBase> _domainEvents = new();
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}