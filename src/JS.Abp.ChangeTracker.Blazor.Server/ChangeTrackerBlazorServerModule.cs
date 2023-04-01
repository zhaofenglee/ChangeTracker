using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker.Blazor.Server;

[DependsOn(
    typeof(ChangeTrackerBlazorModule),
    typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
public class ChangeTrackerBlazorServerModule : AbpModule
{

}
