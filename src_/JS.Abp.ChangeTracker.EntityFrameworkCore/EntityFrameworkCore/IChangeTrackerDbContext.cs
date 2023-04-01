using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.ChangeTracker.EntityFrameworkCore;

[ConnectionStringName(ChangeTrackerDbProperties.ConnectionStringName)]
public interface IChangeTrackerDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
