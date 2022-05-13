namespace VirtualRoulette.Domain.Common;

public class AggregateRoot : Entity, IHasDomainEvent
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> NotCommittedEvents =>
        _domainEvents.Where(domainEvent => !domainEvent.IsCommitted).ToList().AsReadOnly();
    
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void CommitEvents()
    {
        _domainEvents.ForEach(domainEvent => domainEvent.Commit());
    }
}