using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.AspNetCore.Components;

namespace JS.Abp.ChangeTracker.Blazor;

public abstract class ChangeTrackerComponentBase : AbpComponentBase
{
    protected ChangeTrackerComponentBase()
    {
        LocalizationResource = typeof(ChangeTrackerResource);
    }
}
