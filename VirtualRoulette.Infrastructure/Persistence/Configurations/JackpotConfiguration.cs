using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualRoulette.Domain.Entities;

namespace VirtualRoulette.Infrastructure.Persistence.Configurations;

public class JackpotConfiguration : IEntityTypeConfiguration<Jackpot>
{
    public void Configure(EntityTypeBuilder<Jackpot> builder)
    {
        builder.HasKey(j => j.Id);

        builder.HasData(new List<Jackpot>()
        {
            new(new Random().NextInt64())
        });
    }
}