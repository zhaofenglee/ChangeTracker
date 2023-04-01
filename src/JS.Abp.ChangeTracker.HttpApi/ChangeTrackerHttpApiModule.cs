using Localization.Resources.AbpUi;
using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace JS.Abp.ChangeTracker;

[DependsOn(
    typeof(ChangeTrackerApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ChangeTrackerHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ChangeTrackerHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ChangeTrackerResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
