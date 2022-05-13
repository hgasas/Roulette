namespace VirtualRoulette.Domain.ServiceInterfaces;

public interface INumberGenerationService
{
    int GenerateNumber(int min, int max);
}