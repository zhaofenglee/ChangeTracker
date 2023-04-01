using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(ChangeTrackerBlazorModule)
    )]
public class ChangeTrackerBlazorServerModule : AbpModule
{

}
