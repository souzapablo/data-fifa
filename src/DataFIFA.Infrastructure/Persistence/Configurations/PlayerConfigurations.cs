using DataFIFA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataFIFA.Infrastructure.Persistence.Configurations;

public class PlayerConfigurations : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(t => t.CreatedAt)
            .HasDefaultValue(DateTime.Now);
        
        builder.Property(t => t.LastUpdate)
            .HasDefaultValue(DateTime.Now);

        builder.Property(t => t.IsActive)
            .HasDefaultValue(true);
    }
}