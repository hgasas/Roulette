using Microsoft.EntityFrameworkCore;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Domain.Entities;

namespace VirtualRoulette.Infrastructure.Persistence.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext dbContext, IDomainEventService domainEventService, AppDbContext context)
        : base(dbContext, domainEventService)
    {
        _context = context;
    }

    public Task<User> GetByUsernameAsync(string username)
    {
        var loweredUsername = username.ToLower();
        return _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == loweredUsername);
    }
}