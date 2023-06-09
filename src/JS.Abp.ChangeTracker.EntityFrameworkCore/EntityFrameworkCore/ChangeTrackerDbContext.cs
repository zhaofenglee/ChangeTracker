using JS.Abp.ChangeTracker.ChangeLogs;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.ChangeTracker.EntityFrameworkCore;

[ConnectionStringName(ChangeTrackerDbProperties.ConnectionStringName)]
public class ChangeTrackerDbContext : AbpDbContext<ChangeTrackerDbContext>, IChangeTrackerDbContext
{
    public DbSet<ChangeLog> ChangeLogs { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ChangeTrackerDbContext(DbContextOptions<ChangeTrackerDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureChangeTracker();
    }
}