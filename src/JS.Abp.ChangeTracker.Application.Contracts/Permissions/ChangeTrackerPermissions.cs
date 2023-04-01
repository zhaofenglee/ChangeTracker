using Volo.Abp.Reflection;

namespace JS.Abp.ChangeTracker.Permissions;

public class ChangeTrackerPermissions
{
    public const string GroupName = "ChangeTracker";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ChangeTrackerPermissions));
    }

    public static class ChangeLogs
    {
        public const string Default = GroupName + ".ChangeLogs";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}