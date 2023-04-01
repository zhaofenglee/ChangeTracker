using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace JS.Abp.ChangeTracker.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class ChangeTrackerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ChangeTracker";
}
