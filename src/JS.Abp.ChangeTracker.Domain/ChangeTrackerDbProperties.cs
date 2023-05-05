using Volo.Abp.Data;

namespace JS.Abp.ChangeTracker;

public static class ChangeTrackerDbProperties
{
    public static string DbTablePrefix { get; set; } =  AbpCommonDbProperties.DbTablePrefix;

    public static string? DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

    public const string ConnectionStringName = "ChangeTracker";
}
