using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualRoulette.Domain.Entities;
using VirtualRoulette.Infrastructure.Services;

namespace VirtualRoulette.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasData(new List<User>()
        {
            new(new CreateUserArgs()
            {
                PlainPassword = "Admin1234!@#$",
                Username = "Admin",
                IdGenerationService = new IdGenerationService(),
                HashingService = new HashingService()
            })
        });
    }
}