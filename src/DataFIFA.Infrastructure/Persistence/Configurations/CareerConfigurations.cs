using DataFIFA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataFIFA.Infrastructure.Persistence.Configurations;

public class CareerConfigurations : IEntityTypeConfiguration<Career>
{
    public void Configure(EntityTypeBuilder<Career> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Teams)
            .WithOne()
            .HasForeignKey(t => t.CareerId);

        builder.HasOne(c => c.CurrentTeam)
            .WithOne()
            .HasForeignKey<Career>(c => c.CurrentTeamId);
        
        builder.Property(c => c.CreatedAt)
            .HasDefaultValue(DateTime.Now);
        
        builder.Property(c => c.LastUpdate)
            .HasDefaultValue(DateTime.Now);

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);
    }
}