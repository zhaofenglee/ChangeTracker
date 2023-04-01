using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(ChangeTrackerDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ChangeTrackerApplicationContractsModule : AbpModule
{

}
