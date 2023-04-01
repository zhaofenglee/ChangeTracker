using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(ChangeTrackerDomainSharedModule)
)]
public class ChangeTrackerDomainModule : AbpModule
{

}
