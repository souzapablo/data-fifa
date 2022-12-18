using System.Reflection;
using DataFIFA.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataFIFA.Infrastructure.Persistence;

public class DataFifaDbContext : DbContext
{
    public DataFifaDbContext(DbContextOptions<DataFifaDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Career> Careers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}