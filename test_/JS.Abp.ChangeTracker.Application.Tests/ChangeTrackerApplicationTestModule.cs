using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(ChangeTrackerApplicationModule),
    typeof(ChangeTrackerDomainTestModule)
    )]
public class ChangeTrackerApplicationTestModule : AbpModule
{

}
