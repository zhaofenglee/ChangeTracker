using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ChangeTrackerInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ChangeTrackerInstallerModule>();
        });
    }
}
