using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.ChangeTracker.EntityFrameworkCore;

public class ChangeTrackerHttpApiHostMigrationsDbContext : AbpDbContext<ChangeTrackerHttpApiHostMigrationsDbContext>
{
    public ChangeTrackerHttpApiHostMigrationsDbContext(DbContextOptions<ChangeTrackerHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureChangeTracker();
    }
}
