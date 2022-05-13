using System.Security.Cryptography;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Infrastructure.Services;

public class NumberGenerationService : INumberGenerationService
{
    public int GenerateNumber(int min, int max)
    {
        return RandomNumberGenerator.GetInt32(min, max);
    }
}