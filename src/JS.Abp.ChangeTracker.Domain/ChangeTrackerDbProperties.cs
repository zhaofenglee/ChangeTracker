namespace JS.Abp.ChangeTracker;

public static class ChangeTrackerDbProperties
{
    public static string DbTablePrefix { get; set; } = "ChangeTracker";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ChangeTracker";
}
