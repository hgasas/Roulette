namespace VirtualRoulette.Domain.Common;

public abstract class DomainEvent : IDomainEvent
{
    public DateTime DateOccurred { get; }
    
    public bool IsCommitted { get; private set; }
    
    protected DomainEvent()
    {
        DateOccurred = DateTime.UtcNow;
        IsCommitted = false;
    }
    
    public void Commit()
    {
        IsCommitted = true;
    }
}