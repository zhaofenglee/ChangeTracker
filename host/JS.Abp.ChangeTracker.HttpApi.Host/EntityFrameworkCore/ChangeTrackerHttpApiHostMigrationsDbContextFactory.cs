using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JS.Abp.ChangeTracker.EntityFrameworkCore;

public class ChangeTrackerHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ChangeTrackerHttpApiHostMigrationsDbContext>
{
    public ChangeTrackerHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ChangeTrackerHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("ChangeTracker"));

        return new ChangeTrackerHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
