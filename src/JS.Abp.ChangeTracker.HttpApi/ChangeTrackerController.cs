using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JS.Abp.ChangeTracker;

public abstract class ChangeTrackerController : AbpControllerBase
{
    protected ChangeTrackerController()
    {
        LocalizationResource = typeof(ChangeTrackerResource);
    }
}
