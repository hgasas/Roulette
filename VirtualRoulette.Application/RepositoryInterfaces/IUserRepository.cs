namespace VirtualRoulette.Application.RepositoryInterfaces;

public interface IUserRepository : IRepository<Domain.Entities.User>
{
    Task<Domain.Entities.User> GetByUsernameAsync(string username);
}