namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public static class ChangeLogConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ChangeLog." : string.Empty);
        }

        public const int UserNameMaxLength = 128;
        public const int SystemNameMaxLength = 50;
    }
}