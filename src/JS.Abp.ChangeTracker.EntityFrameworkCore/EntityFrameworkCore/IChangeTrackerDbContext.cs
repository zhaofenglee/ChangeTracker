using JS.Abp.ChangeTracker.ChangeLogs;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.ChangeTracker.EntityFrameworkCore;

[ConnectionStringName(ChangeTrackerDbProperties.ConnectionStringName)]
public interface IChangeTrackerDbContext : IEfCoreDbContext
{
    DbSet<ChangeLog> ChangeLogs { get; set; }
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}