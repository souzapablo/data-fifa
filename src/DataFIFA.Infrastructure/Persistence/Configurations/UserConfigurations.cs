using DataFIFA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataFIFA.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.CreatedAt)
            .HasDefaultValue(DateTime.Now);
        
        builder.Property(u => u.LastUpdate)
            .HasDefaultValue(DateTime.Now);

        builder.Property(u => u.IsActive)
            .HasDefaultValue(true);
    }
}