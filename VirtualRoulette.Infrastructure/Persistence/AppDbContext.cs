using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VirtualRoulette.Domain.Common;
using VirtualRoulette.Domain.Entities;

namespace VirtualRoulette.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly IMediator _mediator;
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Bet> Bets { get; set; }
    
    public DbSet<Jackpot> Jackpots { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        // var domainEvents = ChangeTracker
        //     .Entries<IHasDomainEvent>()
        //     .Select(entry => entry.Entity.NotCommittedEvents)
        //     .SelectMany(x => x)
        //     .ToList();
        //
        // foreach (var domainEvent in domainEvents)
        // {
        //     await _mediator.Publish(domainEvent, cancellationToken);
        // }

        return 1;
        //return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}