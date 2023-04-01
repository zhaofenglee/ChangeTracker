using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ChangeTrackerHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ChangeTrackerConsoleApiClientModule : AbpModule
{

}
