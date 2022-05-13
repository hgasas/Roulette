using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Domain.ValueObjects;

public class Password
{
    public string PasswordHash { get; private set; }

    private Password()
    {
    }
    
    public Password(string password, IHashingService hashingService)
    {
        PasswordHash = hashingService.HashPassword(password);
    }
    
    public bool VerifyPassword(string password, IHashingService hashingService)
    {
        return hashingService.VerifyHashedPassword(password, PasswordHash);
    }
}