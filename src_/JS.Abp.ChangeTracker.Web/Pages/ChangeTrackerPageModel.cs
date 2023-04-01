using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JS.Abp.ChangeTracker.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ChangeTrackerPageModel : AbpPageModel
{
    protected ChangeTrackerPageModel()
    {
        LocalizationResourceType = typeof(ChangeTrackerResource);
        ObjectMapperContext = typeof(ChangeTrackerWebModule);
    }
}
