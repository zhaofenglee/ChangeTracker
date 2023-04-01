using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace JS.Abp.ChangeTracker;

[Dependency(ReplaceServices = true)]
public class ChangeTrackerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ChangeTracker";
}
