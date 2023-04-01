using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JS.Abp.ChangeTracker.Permissions;

public class ChangeTrackerPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ChangeTrackerPermissions.GroupName, L("Permission:ChangeTracker"));

        var changeLogPermission = myGroup.AddPermission(ChangeTrackerPermissions.ChangeLogs.Default, L("Permission:ChangeLogs"));
        changeLogPermission.AddChild(ChangeTrackerPermissions.ChangeLogs.Create, L("Permission:Create"));
        changeLogPermission.AddChild(ChangeTrackerPermissions.ChangeLogs.Edit, L("Permission:Edit"));
        changeLogPermission.AddChild(ChangeTrackerPermissions.ChangeLogs.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ChangeTrackerResource>(name);
    }
}