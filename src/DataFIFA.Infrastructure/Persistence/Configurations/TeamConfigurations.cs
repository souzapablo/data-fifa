using DataFIFA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataFIFA.Infrastructure.Persistence.Configurations;

public class TeamConfigurations : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.CreatedAt)
            .HasDefaultValue(DateTime.Now);
        
        builder.Property(t => t.LastUpdate)
            .HasDefaultValue(DateTime.Now);

        builder.Property(t => t.IsActive)
            .HasDefaultValue(true);
    }
}