namespace VirtualRoulette.Domain.Common;

public interface IDomainEvent
{
    DateTime DateOccurred { get; }
    
    bool IsCommitted { get; }
    
    void Commit();
}