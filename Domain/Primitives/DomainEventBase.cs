using MediatR;

namespace Domain.Primitives;

public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.Now;
}
