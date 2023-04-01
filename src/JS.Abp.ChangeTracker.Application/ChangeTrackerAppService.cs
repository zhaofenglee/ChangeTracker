using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.Application.Services;

namespace JS.Abp.ChangeTracker;

public abstract class ChangeTrackerAppService : ApplicationService
{
    protected ChangeTrackerAppService()
    {
        LocalizationResource = typeof(ChangeTrackerResource);
        ObjectMapperContext = typeof(ChangeTrackerApplicationModule);
    }
}
