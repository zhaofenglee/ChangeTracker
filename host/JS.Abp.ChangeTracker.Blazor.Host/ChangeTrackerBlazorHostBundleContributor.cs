using Volo.Abp.Bundling;

namespace JS.Abp.ChangeTracker.Blazor.Host;

public class ChangeTrackerBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
