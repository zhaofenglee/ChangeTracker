using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(ChangeTrackerDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationAbstractionsModule)
    )]
public class ChangeTrackerApplicationContractsModule : AbpModule
{

}
