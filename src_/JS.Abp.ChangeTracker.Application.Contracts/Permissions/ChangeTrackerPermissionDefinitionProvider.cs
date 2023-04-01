using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JS.Abp.ChangeTracker.Permissions;

public class ChangeTrackerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ChangeTrackerPermissions.GroupName, L("Permission:ChangeTracker"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ChangeTrackerResource>(name);
    }
}
