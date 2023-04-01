using JS.Abp.ChangeTracker.ChangeLogs;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JS.Abp.ChangeTracker.EntityFrameworkCore;

[DependsOn(
    typeof(ChangeTrackerDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ChangeTrackerEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ChangeTrackerDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<ChangeLog, ChangeLogs.EfCoreChangeLogRepository>();

        });
    }
}