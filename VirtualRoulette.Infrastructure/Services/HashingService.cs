using System.Security.Cryptography;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Infrastructure.Services;

public class HashingService : IHashingService
{
    private const int SaltSize = 16;
    private const int IterationsCount = 10000;
    private const int KeySize = 32;
    private const char Delimiter = ':';
    
    public string HashPassword(string password)
    {
        var salt = GenerateSalt();
        var hash = GenerateHash(password, salt);
        
        return hash;
    }

    public bool VerifyHashedPassword(string password, string storedHash)
    {
        var salt = Convert.FromBase64String(storedHash.Split(Delimiter)[0]);

        return storedHash == GenerateHash(password, salt);
    }

    private static string GenerateHash(string password, byte[] salt)
    {
        var deriveBytes = new Rfc2898DeriveBytes(password, salt, IterationsCount);
        
        return $"{Convert.ToBase64String(salt)}{Delimiter}{Convert.ToBase64String(deriveBytes.GetBytes(KeySize))}";
    }

    private static byte[] GenerateSalt()
    {
        var salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }
}