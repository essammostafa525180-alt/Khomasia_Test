namespace Domain.Primitives;

public interface IAggregateRoot
{
    IEnumerable<DomainEventBase> DomainEvents { get; }
}
