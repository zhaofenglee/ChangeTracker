using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JS.Abp.ChangeTracker.Pages;

public abstract class ChangeTrackerPageModel : AbpPageModel
{
    protected ChangeTrackerPageModel()
    {
        LocalizationResourceType = typeof(ChangeTrackerResource);
    }
}
