using IdGen;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Infrastructure.Services;

public class IdGenerationService : IIdGenerationService
{
    private const int GeneratorId = 123;
    private readonly IdGenerator _idGenerator = new(GeneratorId);
    
    public long GenerateId()
    {
        return _idGenerator.CreateId();
    }
}