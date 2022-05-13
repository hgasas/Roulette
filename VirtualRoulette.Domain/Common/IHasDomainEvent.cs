namespace VirtualRoulette.Domain.Common;

public interface IHasDomainEvent
{
    IReadOnlyCollection<IDomainEvent> NotCommittedEvents { get; }
    
    void AddDomainEvent(IDomainEvent domainEvent);
    
    void CommitEvents();
}