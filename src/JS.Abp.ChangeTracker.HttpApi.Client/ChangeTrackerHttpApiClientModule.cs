using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(ChangeTrackerApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ChangeTrackerHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ChangeTrackerApplicationContractsModule).Assembly,
            ChangeTrackerRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ChangeTrackerHttpApiClientModule>();
        });
    }
}
