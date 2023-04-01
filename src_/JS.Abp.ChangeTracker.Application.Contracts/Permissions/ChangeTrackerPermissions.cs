using Volo.Abp.Reflection;

namespace JS.Abp.ChangeTracker.Permissions;

public class ChangeTrackerPermissions
{
    public const string GroupName = "ChangeTracker";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ChangeTrackerPermissions));
    }
}
