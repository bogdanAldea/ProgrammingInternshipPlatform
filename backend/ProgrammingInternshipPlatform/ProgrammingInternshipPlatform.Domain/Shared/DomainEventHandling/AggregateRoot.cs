namespace ProgrammingInternshipPlatform.Domain.Shared.DomainEventHandling;

public abstract class AggregateRoot
{
    protected readonly List<DomainEvent> _domainEvents = new();
    public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;
    public void PublicDomainEvent(DomainEvent @event) => _domainEvents.Add(@event);
}