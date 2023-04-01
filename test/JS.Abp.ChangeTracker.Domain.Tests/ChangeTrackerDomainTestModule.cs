using JS.Abp.ChangeTracker.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ChangeTrackerEntityFrameworkCoreTestModule)
    )]
public class ChangeTrackerDomainTestModule : AbpModule
{

}
