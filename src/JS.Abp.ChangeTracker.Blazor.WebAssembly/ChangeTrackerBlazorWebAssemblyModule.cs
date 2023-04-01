using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker.Blazor.WebAssembly;

[DependsOn(
    typeof(ChangeTrackerBlazorModule),
    typeof(ChangeTrackerHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
)]
public class ChangeTrackerBlazorWebAssemblyModule : AbpModule
{

}
